using GameFramework.DataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame {
    public class PlayerData : ActorData
    {
        [SerializeField]
        private ActorEquips actorEquips = null;
        [SerializeField]
        private string m_Name;

        
        public PlayerData(int entityId, int typeId) 
            : base(entityId, typeId)
        {
        }

        public override int MaxHP => throw new System.NotImplementedException();

        public override int MaxSP => throw new System.NotImplementedException();

        public string Name { get => m_Name; set => m_Name = value; }
    }
}
