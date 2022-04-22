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
        private List<Actor> m_battleActors = new List<Actor>();
        private Dictionary<int, Actor> camp1Dic;  //单机模式下通常指玩家阵营
        private Dictionary<int, Actor> camp2Dic;  //单机模式下通常指npc敌人阵营

        private int m_CurActorIndex = 0;
        private Actor m_CurActor => m_battleActors[m_CurActorIndex];
        public Actor CurActor => m_CurActor;
        

        IFsm<BattleMgr> fsm;
        IFsm<BattleState> battleStateFsm;

        protected override void OnInit(IFsm<BattleMgr> fsm)
        {
            m_battleActors = fsm.Owner.battleActors;
            m_battleActors.Sort();

            camp1Dic = new Dictionary<int, Actor>();
            camp2Dic = new Dictionary<int, Actor>();
        }
        protected override void OnEnter(IFsm<BattleMgr> fsm)
        {
            base.OnEnter(fsm);
         
            foreach (var a in m_battleActors)
            {
                if (a.tag == "Player")
                {
                    //a.gameObject.tag = "Player";
                    camp1Dic.Add(1, a);
                }
                else if(a.tag == "Enemy")
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
            Log.Debug(fsm.CurrentState);
        }

        protected override void OnDestroy(IFsm<BattleMgr> fsm)
        {
            base.OnDestroy(fsm);
            m_battleActors.Clear();
            m_battleActors = null;
            camp1Dic.Clear();
            camp1Dic = null;
            camp2Dic.Clear();
            camp2Dic = null;

            fsm = null;
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
        protected override void OnInit(IFsm<BattleState> fsm)
        {
            base.OnInit(fsm);
            //GameEntry.Event.Fire(this, ActorRoundStartEventArgs.Create(fsm.Owner.CurActor.ActorData.Id));
        }
        protected override void OnEnter(IFsm<BattleState> fsm)
        {
            base.OnEnter(fsm);
#if UNITY_EDITOR
            Log.Info("Actor Round Start!");
#endif
        }
        protected override void OnUpdate(IFsm<BattleState> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            //when round start animation play over then change state
            if (elapseSeconds > 2f)
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
        protected override void OnInit(IFsm<BattleState> fsm)
        {
            base.OnInit(fsm);
            GameEntry.Event.Subscribe(ActorRoundFinishEventArgs.EventId, OnActorRoundFinish);
            this.fsm = fsm;
        }

        protected override void OnEnter(IFsm<BattleState> fsm)
        {
            base.OnEnter(fsm);

#if UNITY_EDITOR
            Log.Info($"Actor {fsm.Owner.CurActor.ActorData.Id} Round Do!");
#endif
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
    public class BattleRoundEndState: FsmState<BattleState>
    {
        protected override void OnUpdate(IFsm<BattleState> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            //等待回合结束动画播放
            if (elapseSeconds > 2f)
            {
                ChangeState<BattleRoundStartState>(fsm);
            }
        }

        protected override void OnLeave(IFsm<BattleState> fsm, bool isShutdown)
        {
            //切换到下一个Actor
            fsm.Owner.ShiftToNextActor();
            base.OnLeave(fsm, isShutdown);
        }
    }
}
