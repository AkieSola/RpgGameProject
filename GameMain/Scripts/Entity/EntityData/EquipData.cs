using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public enum E_EquipType
    {
        weapon = 1,
        cloth = 2,

    }

    public enum E_EquipRare
    {

    }
    public class EquipData : EntityData
    {
        [SerializeField]
        private int m_Id = 0;      //装备ID

        [SerializeField]
        private string m_EquipName = "";    //装备姓名

        [SerializeField]
        private string m_EquipDescription = "";     //装备描述

        [SerializeField]
        private string m_EquipPath = "";    //资源名称

        [SerializeField]
        private int m_PhysicsAttack = 0;    //物理攻击力加成

        [SerializeField]
        private int m_SpellAttack = 0;      //魔法攻击力加成

        [SerializeField]
        private int m_PhysicsDefense = 0;   //物理抗性加成

        [SerializeField]
        private int m_SpellDefense = 0;     //魔法抗性加成

        [SerializeField]
        private int m_Level = 0;    //装备等级

        [SerializeField]
        private int m_EquipType = 0;    //装备类型 
        /// 0 无类型
        /// 1 武器
        /// 2 防具
        [SerializeField]
        private int m_SubEquipType;  //装备子类型             

        [SerializeField]
        private int m_EquipRare;    //稀有度
                                    /// 1 普通
                                    /// 2 稀有
                                    /// 3 史诗
                                    /// 4 传说

        public EquipData(int entityId, int typeId, int ownerId) : base(entityId, typeId)
        {

        }
    }
}
