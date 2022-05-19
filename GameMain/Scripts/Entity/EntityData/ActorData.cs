using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    /// <summary>
    /// Player通过属性点（二级属性）+装备映射到ActorData的基础属性
    /// NPC和Enemy通过配表来决定这些ActorData的基础属性
    /// </summary>
    public abstract class ActorData : EntityData
    {
        [SerializeField]
        private int m_Id;       
        [SerializeField]
        private int m_HP = 1;                           //生命值
        [SerializeField]
        private int m_MaxHP = 1;                        //最大生命
        [SerializeField]
        private int m_SP = 1;                           //行动值
        [SerializeField]
        private int m_MaxSp = 1;                        //最大行动
        [SerializeField]
        private float m_Priority = 0;                   //先攻值
        [SerializeField]
        private float m_Atk = 1;                        //攻击力
        [SerializeField]
        private float m_SpellAtk = 1;                   //法术强度
        [SerializeField]
        private float m_AtkDistance = 1;                //攻击距离
        [SerializeField]
        private float m_PhysicsDfs = 0;                 //物理抗性
        [SerializeField]
        private float m_SpellDfs = 0;                   //魔法抗性
        [SerializeField]
        private CampType m_Camp = CampType.Unknown;     //阵营


        public ActorData(int entityId, int typeId) : base(entityId, typeId)
        {

        }

        public float Speed { get; set; }
        public int ActorId { get => m_Id; set => m_Id = value; }
        public int HP { get => m_HP; set => m_HP = Math.Min(Math.Max(0, value), MaxHP); }
        public int MaxHP { get => m_MaxHP; set => m_MaxHP = value; }
        public int SP { get => m_SP; set => m_SP = Math.Min(Math.Max(0, value), MaxSP); }
        public int MaxSP { get => m_MaxSp; set => m_MaxSp = value; }
        public float Priority { get => m_Priority; set => m_Priority = value; }
        public float Atk { get => m_Atk; set => m_Atk = Math.Max(0, value); }
        public float SpellAtk { get => m_SpellAtk; set => m_SpellAtk = value; }
        public float AtkDistance { get => m_AtkDistance; set => m_AtkDistance = Math.Max(0, value); }
        public float PhysicsDfs { get => m_PhysicsDfs; set => m_PhysicsDfs = value; }
        public float SpellDfs { get => m_SpellDfs; set => m_SpellDfs = value; }

        /// <summary>
        /// 生命值百分比
        /// </summary>
        public float HPRatio { get => Math.Max(0, (float)m_HP / (float)m_MaxHP); }
        /// <summary>
        /// SP值百分比
        /// </summary>
        public float SPRatio { get => Math.Max(0, (float)m_SP / (float)m_MaxSp); }
        /// <summary>
        /// 物抗百分比
        /// </summary>
        public float PhysicsDfsRatio { get => (float)PhysicsDfs / (float)(100 + PhysicsDfs); }
        /// <summary>
        /// 魔抗百分比
        /// </summary>
        public float SpellDfsRatio { get => (float)SpellDfs / (float)(100 + SpellDfs); }
        /// <summary>
        /// 角色是否死亡
        /// </summary>
        public bool IsDead { get => m_HP <= 0; }
       
    }
}