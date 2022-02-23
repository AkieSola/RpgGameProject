using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame {
    public class BattleMgr : MonoBehaviour
    {
        private List<Actor> battleActors;
        private Dictionary<int, Actor> camp1Dic;  //单机模式下通常指玩家阵营
        private Dictionary<int, Actor> camp2Dic;  //单机模式下通常指npc敌人阵营

        private int m_CurActorIndex;

        private IFsm<BattleMgr> m_Fsm = null;


        public Actor CurActor
        {
            get => battleActors[m_CurActorIndex];
        }


        public void OnInit(List<Actor> actors)
        {
            battleActors = actors;
            foreach(var a in actors)
            {
                if(a.ActorData.Camp == CampType.Player)
                {
                    camp1Dic.Add(a.ActorData.Id, a);
                }
                else if(a.ActorData.Camp == CampType.Enemy)
                {
                    camp2Dic.Add(a.ActorData.Id, a);
                }
            }

            //名称：BattleMgrFsm | Owner: this | 状态：BattleRoundStartState，BattleRoundDoState，BattleRoundEndState
            m_Fsm = GameEntry.Fsm.CreateFsm("BattleMgrFsm", this, new BattleRoundStartState(), new BattleRoundDoState(), new BattleRoundEndState());
            lineSort();
        }

        // Start is called before the first frame update
        void Start()
        {
            m_Fsm.Start<BattleRoundStartState>();  
        }

        public bool CheckBattleEnd()
        {
            if (camp1Dic.Count == 0 || camp2Dic.Count == 0)
            {
                return true;
            }

            return false;
        }

        public void ShiftToNextActor()
        {
            if (m_CurActorIndex == battleActors.Count - 1)
            {
                m_CurActorIndex = 0;     
            }
            else
            {
                m_CurActorIndex++;
            }
        }

        public void RemoveActor(int id)
        {
            for(int i = 0; i < battleActors.Count; i++)
            {
                if(battleActors[i].ActorData.Id == id)
                {
                    battleActors.RemoveAt(i);
                    camp1Dic.Remove(id);
                    camp2Dic.Remove(id);
                }
            }
        }

        private void EndBattle()
        {
        }

        void LaunchAttack()
        {
        }

        void lineSort()
        {
            battleActors.Sort();
        }

        //IEnumerator WaitForTakeDamage()
        //{
        //}
    }

    public class BattleRoundStartState : FsmState<BattleMgr>
    {
        protected override void OnEnter(IFsm<BattleMgr> fsm)
        {
            base.OnEnter(fsm); 
            
        }

        protected override void OnLeave(IFsm<BattleMgr> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }
    }

    public class BattleRoundDoState : FsmState<BattleMgr>
    {
        protected override void OnEnter(IFsm<BattleMgr> fsm)
        {
            base.OnEnter(fsm);
        }
    }

    public class BattleRoundEndState : FsmState<BattleMgr>
    {
        protected override void OnEnter(IFsm<BattleMgr> fsm)
        {
            base.OnEnter(fsm);
        }

        protected override void OnLeave(IFsm<BattleMgr> fsm, bool isShutdown)
        {
            //轮换下个角色
            fsm.Owner.ShiftToNextActor();
            base.OnLeave(fsm, isShutdown);
        }
    }
}

