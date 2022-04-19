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
        public Player player;
        protected override void OnInit(IFsm<BattleMgr> fsm)
        {
            base.OnInit(fsm);
            battleActors = new List<Actor>();
            player = fsm.Owner.player;
        }

        protected override void OnUpdate(IFsm<BattleMgr> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            Log.Debug("NormalState OnUpdate");
            if (player != null)
            {
                Collider[] colliders = Physics.OverlapSphere(player.transform.position, 10);
                foreach (var collider in colliders)
                {
                    Actor a;
                    if (collider.TryGetComponent<Actor>(out a))
                    {
                        if (a != null)
                        {
                            battleActors.Add(a);
                        }
                    }
                }
            }
        }
    }
}
