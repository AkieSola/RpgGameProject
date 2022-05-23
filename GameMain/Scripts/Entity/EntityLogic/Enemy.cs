using GameFramework;
using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame 
{
    public class Enemy : Actor
    {
        [SerializeField]
        private EnemyData m_EnemyData;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            this.ActorData.Camp = CampType.Enemy;

            ActorState = GameEntry.Fsm.CreateFsm((Actor)this,new ActorNomralState(),new ActorDialogState(),new ActorBattleState());

            ActorState.Start<ActorNomralState>();

            m_EnemyData = userData as EnemyData;

            GameEntry.HPBar.ShowHPBar(this, 1, this.m_EnemyData.HPRatio);
      
            if(m_EnemyData == null)
            {
                Log.Error("EnemyData is invalid.");
                return;
            }
            Name = Utility.Text.Format("Monster({0})", Id);
        }
    }
}


