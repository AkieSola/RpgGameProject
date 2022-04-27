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
            battleMgrFsm = GameEntry.Fsm.CreateFsm(this, new NormalState(),new BattleState());
            battleMgrFsm.Start<NormalState>();
        }
    }

}

