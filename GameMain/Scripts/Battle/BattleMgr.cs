using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame {
    public class BattleMgr : MonoBehaviour
    {
        IFsm<BattleMgr> battleMgrFsm;

        public List<Actor> battleActors;

        private void Start()
        {
            battleActors = new List<Actor>();

            battleMgrFsm = GameEntry.Fsm.CreateFsm<BattleMgr>(this,new BattleState(),new NormalState());

            Collider[] colliders = Physics.OverlapSphere(this.transform.position, 10);
            foreach(var collider in colliders)
            {
                Actor a;
                if(collider.TryGetComponent<Actor>(out a))
                {
                    if (a != null)
                    {
                        battleActors.Add(a);
                    }
                }
            }

            battleMgrFsm.Start<BattleState>();
        }
    }
}

