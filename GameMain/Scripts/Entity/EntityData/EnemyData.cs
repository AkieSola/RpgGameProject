using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class EnemyData : ActorData
    {
        [SerializeField]
        private int m_Id;
        [SerializeField]
        private string m_Name;
        [SerializeField]
        private int m_Lv;
        [SerializeField]
        private int m_DropId;           //µôÂäID
        [SerializeField]
        private int m_AIId;              //AItable Id

        public EnemyData(DREnemy dREnemy, int entityId, int typeId) : base(entityId, typeId)
        {
            m_Id = dREnemy.Id;
            Name = dREnemy.Name;
            m_Lv = dREnemy.Lv;
            m_DropId = dREnemy.DropId;
            m_AIId = dREnemy.AIId;

            base.MaxHP = dREnemy.MaxHp;
            base.MaxSP = dREnemy.MaxSp;
            base.Priority = dREnemy.Priority;
            base.Atk = dREnemy.Atk;
            base.SpellAtk = dREnemy.SpellAtk;
            base.AtkDistance = dREnemy.AtkDistance;
            base.PhysicsDfs = dREnemy.PhysicsDfs;
            base.SpellDfs = dREnemy.SpellDfs;
        }

        public string Name { get => m_Name; set => m_Name = value; }
    }
}
