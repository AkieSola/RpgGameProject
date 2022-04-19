using GameFramework.Event;
using GameFramework.Fsm;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame {
    public class BattleMgr : MonoBehaviour
    {
        IFsm<BattleMgr> battleMgrFsm;

        public List<Actor> battleActors;

        public float timer = 0;

        public Player player;

        private void Awake()
        {
            GameEntry.Event.Subscribe(PlayerShowEventArgs.EventId, PlayerSearch);
        }

        private void PlayerSearch(object sender, GameEventArgs e)
        {
            player = sender as Player;
        }

        private void Start()
        {
            battleActors = new List<Actor>();
            battleMgrFsm = GameEntry.Fsm.CreateFsm<BattleMgr>(this,new BattleState(),new NormalState());
            battleMgrFsm.Start<NormalState>();
        }

        private void Update() 
        {
            timer += Time.deltaTime;
            if (timer > 1) 
            {
                Collider[] colliders = Physics.OverlapSphere(this.transform.position, 10);
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

                if (battleActors != null)
                {
     
                }
            }
        }
    }

}

