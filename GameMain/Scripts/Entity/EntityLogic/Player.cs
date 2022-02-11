using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public class Player : Actor
    {
        [SerializeField]
        private PlayerData m_PlayerData = null;

        public override ImpactData GetImpactData()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_PlayerData = userData as PlayerData;
            if(m_PlayerData == null)
            {
                Log.Error("Player data is invalid.");
                return;
            }

            Name = Utility.Text.Format("Player ({0})", Id);

            GameEntry.Entity.ShowPlayer(m_PlayerData);
        }
    }
}
