using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public class NormalState : FsmState<BattleMgr>
    {
        public List<Actor> battleActors;
        private float timer;

        private Player player;
        protected override void OnInit(IFsm<BattleMgr> fsm)
        {
            base.OnInit(fsm);
            battleActors = new List<Actor>();
            player = fsm.Owner.player;
        }

        protected override void OnEnter(IFsm<BattleMgr> fsm)
        {
            base.OnEnter(fsm);
            if (player != null)
            {
                player.canMove = true;
                player.inPlayerTurn = false;
            }
        }

        protected override void OnUpdate(IFsm<BattleMgr> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            //timer += Time.deltaTime;
            //if (timer >= 1f)
            //{
            //    timer = 0;
            //    if (fsm.Owner.player != null)
            //    {
            //        Collider[] colliders = Physics.OverlapSphere(fsm.Owner.player.transform.position, 10);
            //        battleActors.Clear();
            //        foreach (var collider in colliders)
            //        {
            //            Actor a;
            //            if (collider.TryGetComponent<Actor>(out a))
            //            {
            //                if (a != null)
            //                {
            //                    Log.Debug(fsm.CurrentState);
            //                    battleActors.Add(a);
            //                }
            //            }
            //        }

            //        if (battleActors.Count > 1)
            //        {
            //            fsm.Owner.battleActors = battleActors;
            //            ChangeState<BattleState>(fsm);
            //        }
            //    }
            //}
        }
    }
}
