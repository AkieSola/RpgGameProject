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
        private int m_DropId;           //µÙ¬‰ID
        [SerializeField]
        private int m_AIId;              //AItable Id
        [SerializeField]
        private int m_GroupId;
        [SerializeField]
        private List<int> m_SkillIdList;

        public EnemyData(DREnemy dREnemy, int entityId, int typeId) : base(entityId, typeId)
        {
            m_Id = dREnemy.Id;
            Name = dREnemy.Name;
            m_Lv = dREnemy.Lv;
            m_DropId = dREnemy.DropId;
            m_AIId = dREnemy.AIId;
            m_SkillIdList = new List<int>() { 
                dREnemy.Skill1Id, dREnemy.Skill2Id, dREnemy.Skill3Id, dREnemy.Skill4Id, 
                dREnemy.Skill5Id, dREnemy.Skill6Id, dREnemy.Skill7Id, dREnemy.Skill8Id 
            };
            m_GroupId = dREnemy.GroupId;

            base.MaxHP = dREnemy.MaxHp;
            HP = MaxHP;
            base.MaxSP = dREnemy.MaxSp;
            SP = MaxSP;
            base.Priority = dREnemy.Priority;
            base.Atk = dREnemy.Atk;
            base.SpellAtk = dREnemy.SpellAtk;
            base.AtkDistance = dREnemy.AtkDistance;
            base.PhysicsDfs = dREnemy.PhysicsDfs;
            base.SpellDfs = dREnemy.SpellDfs;
            
        }

        public string Name { get => m_Name; set => m_Name = value; }
        public int GroupId { get => m_GroupId;}

        public List<int> SkillIdList { get => m_SkillIdList; }
    }
}
