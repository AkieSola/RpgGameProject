using GameFramework.DataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame {
    public class PlayerData : ActorData
    {
        [SerializeField]
        private int m_MaxHP = 0;

        [SerializeField]
        private int m_MaxSP = 0;
        public PlayerData(int entityId, int typeId, CampType camp) 
            : base(entityId, typeId, camp)
        {
            
        }

        public override int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }

        public override int MaxSP
        {
            get
            {
                return m_MaxSP;
            }
        }
    }
}
