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

        public EnemyData EnemyData { get => m_EnemyData; }
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            this.ActorData.Camp = CampType.Enemy;

            ActorState = GameEntry.Fsm.CreateFsm((Actor)this, new ActorNomralState(), new ActorDialogState(), new ActorBattleState());

            ActorState.Start<ActorNomralState>();

            m_EnemyData = userData as EnemyData;

            GameEntry.HPBar.ShowHPBar(this, 1, this.EnemyData.HPRatio);

            if (EnemyData == null)
            {
                Log.Error("EnemyData is invalid.");
                return;
            }

            for (int i = 0; i < EnemyData.SkillIdList.Count; i++)
            {
                SkillList[i] = SkillFactor.CreateSkill(EnemyData.SkillIdList[i], this);
            }

            Name = Utility.Text.Format("Monster({0})", Id);
        }
    }
}


