using GameFramework;
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

            m_EnemyData = userData as EnemyData;
            if(m_EnemyData == null)
            {
                Log.Error("EnemyData is invalid.");
                return;
            }
            Name = Utility.Text.Format("Monster({0})", Id);
        }
    }
}
