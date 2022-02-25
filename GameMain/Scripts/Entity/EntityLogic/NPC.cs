using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class NPC : Actor
    {
        [SerializeField]
        private NPCData m_npcData = null;
        public override ImpactData GetImpactData()
        {
            throw new System.NotImplementedException();
        }
    }
}
