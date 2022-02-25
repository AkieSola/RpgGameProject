using GameFramework.DataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame {
    public class PlayerData : ActorData
    {
        [SerializeField]
        private ActorEquips actorEquips = null;

        public PlayerData(int entityId, int typeId, CampType camp) 
            : base(entityId, typeId, camp)
        {
            
        }

        public override int MaxHP => throw new System.NotImplementedException();

        public override int MaxSP => throw new System.NotImplementedException();
    }
}
