using GameFramework.Event;
using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public class BattleState : FsmState<BattleMgr>
    {
        private List<Actor> m_battleActors;
        private Dictionary<int, Actor> camp1Dic;  //单机模式下通常指玩家阵营
        private Dictionary<int, Actor> camp2Dic;  //单机模式下通常指npc敌人阵营

        private int m_CurActorIndex = 0;
        public Actor CurActor
        {
            get
            {
                if (m_CurActorIndex < m_battleActors.Count)
                {
                    return m_battleActors[m_CurActorIndex];
                }

                return null;
            }
        }


        IFsm<BattleMgr> fsm;
        IFsm<BattleState> battleStateFsm;
        public Player player;

        protected override void OnInit(IFsm<BattleMgr> fsm)
        {
            camp1Dic = new Dictionary<int, Actor>();
            camp2Dic = new Dictionary<int, Actor>();
        }
        protected override void OnEnter(IFsm<BattleMgr> fsm)
        {
            base.OnEnter(fsm);
            player = fsm.Owner.player;
            m_battleActors = fsm.Owner.battleActors;
            m_battleActors.Sort();
            m_CurActorIndex = 0;
            foreach (var a in m_battleActors)
            {
                if (a.tag == "Player")
                {
                    //a.gameObject.tag = "Player";
                    camp1Dic.Add(1, a);
                }
                else if (a.tag == "Enemy")
                {
                    //a.gameObject.tag = "Enemy";
                    camp2Dic.Add(2, a);
                }
            }
            battleStateFsm = GameEntry.Fsm.CreateFsm<BattleState>(this, new BattleRoundStartState(), new BattleRoundDoState(), new BattleRoundEndState());
            battleStateFsm.Start<BattleRoundStartState>();
            this.fsm = fsm;
        }

        protected override void OnUpdate(IFsm<BattleMgr> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnDestroy(IFsm<BattleMgr> fsm)
        {
            base.OnDestroy(fsm);
            m_battleActors.Clear();
            camp1Dic.Clear();
            camp2Dic.Clear();
        }


        public void RemoveActor(int id, IFsm<BattleMgr> fsm)
        {
            for (int i = 0; i < m_battleActors.Count; i++)
            {
                if (m_battleActors[i].ActorData.Id == id)
                {
                    if (m_battleActors[i].gameObject.tag == "Player")
                    {
                        if (camp1Dic.ContainsKey(id))
                        {
                            camp1Dic.Remove(id);

                            if (fsm != null && camp1Dic.Count == 0)
                            {
                                ChangeState<NormalState>(fsm);
                            }
                        }
                    }

                    if (m_battleActors[i].gameObject.tag == "Enemy")
                    {
                        if (camp2Dic.ContainsKey(id))
                        {
                            camp2Dic.Remove(id);

                            if (fsm != null && camp2Dic.Count == 0)
                            {
                                ChangeState<NormalState>(fsm);
                            }
                        }
                    }

                    m_battleActors.RemoveAt(i);
                }
            }
        }

        public void ShiftToNextActor()
        {
            Debug.LogWarning("Shift To Next!");
            if (m_CurActorIndex == m_battleActors.Count - 1)
            {
                m_CurActorIndex = 0;
            }
            else
            {
                m_CurActorIndex++;
            }
        }
    }

    /// <summary>
    /// 回合开始
    /// </summary>
    public class BattleRoundStartState : FsmState<BattleState>
    {
        float timer = 0;
        protected override void OnInit(IFsm<BattleState> fsm)
        {
            base.OnInit(fsm);
            //GameEntry.Event.Fire(this, ActorRoundStartEventArgs.Create(fsm.Owner.CurActor.ActorData.Id));
        }
        protected override void OnEnter(IFsm<BattleState> fsm)
        {
            base.OnEnter(fsm);
            GameEntry.Event.Fire(this, ActorRoundStartEventArgs.Create(fsm.Owner.CurActor));
            timer = 0;
            //非角色回合玩家不能走路
            if (fsm.Owner.CurActor.tag != "Player")
            {
                fsm.Owner.player.canMove = false;
                fsm.Owner.player.inPlayerTurn = false;
            }
            else
            {
                fsm.Owner.player.canMove = true;
                fsm.Owner.player.inPlayerTurn = true;
            }

#if UNITY_EDITOR
            if (fsm.Owner.CurActor != null)
            {
                fsm.Owner.CurActor.RestoreSP();
                Log.Info(fsm.Owner.CurActor + "：的回合");
            }
#endif
        }
        protected override void OnUpdate(IFsm<BattleState> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            //Log.Debug("回合开始");
            //when round start animation play over then change state
            timer += elapseSeconds;
            if (timer > 2f)
            {
                ChangeState<BattleRoundDoState>(fsm);
            }

        }

        protected override void OnLeave(IFsm<BattleState> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }
    }


    /// <summary>
    /// 回合进行
    /// </summary>
    public class BattleRoundDoState : FsmState<BattleState>
    {
        IFsm<BattleState> fsm;
        float timer = 0;
        protected override void OnInit(IFsm<BattleState> fsm)
        {
            base.OnInit(fsm);
            GameEntry.Event.Subscribe(ActorRoundFinishEventArgs.EventId, OnActorRoundFinish);
            this.fsm = fsm;
        }

        protected override void OnEnter(IFsm<BattleState> fsm)
        {
            base.OnEnter(fsm);
            timer = 0;
#if UNITY_EDITOR
            Log.Info($"Actor {fsm.Owner.CurActor.ActorData.Id} Round Do!");
#endif
        }

        protected override void OnUpdate(IFsm<BattleState> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            //Enemy执行AI逻辑，执行结束后进入回合结束状态
            if (fsm.Owner.CurActor.tag == "Enemy")
            {
                timer += realElapseSeconds;

                if (timer > 2)
                {
                    ChangeState<BattleRoundEndState>(fsm);
                }
            }

        }

        private void OnActorRoundFinish(object sender, GameEventArgs e)
        {
            if (fsm != null)
            {
                ChangeState<BattleRoundEndState>(fsm);
            }
        }
    }


    /// <summary>
    /// 回合结束
    /// </summary>
    public class BattleRoundEndState : FsmState<BattleState>
    {
        float timer = 0;
        protected override void OnEnter(IFsm<BattleState> fsm)
        {
            base.OnEnter(fsm);
            timer = 0;
            Log.Debug(fsm.Owner.CurActor.tag + "：回合结束");
        }

        protected override void OnUpdate(IFsm<BattleState> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            timer += elapseSeconds;
            //等待回合结束动画播放
            if (timer > 2f)
            {
                ChangeState<BattleRoundStartState>(fsm);
            }
        }

        protected override void OnLeave(IFsm<BattleState> fsm, bool isShutdown)
        {
            Debug.LogWarning("OnLeave");
            //切换到下一个Actor
            fsm.Owner.ShiftToNextActor();
            base.OnLeave(fsm, isShutdown);
        }
    }
}
