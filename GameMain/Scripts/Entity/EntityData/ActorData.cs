using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public abstract class ActorData : EntityData
    {
        [SerializeField]                                
        private int m_HP = 1;                           //生命值
        [SerializeField]   
        private int m_SP = 1;                           //行动值
        [SerializeField]
        private float m_Priority = 0;                   //先攻值
        [SerializeField]
        private CampType m_Camp = CampType.Unknown;     //阵营
        [SerializeField]
        private int m_Power = 0;                        //力量
        [SerializeField]
        private int m_Agile = 0;                        //敏捷
        [SerializeField]
        private int m_Intelligence = 0;                 //智力
        [SerializeField]
        private int m_Luck = 0;                         //运气
        [SerializeField]
        private int m_PhysicalAtk = 0;                  //物理攻击
        [SerializeField]
        private int m_SpellAtk = 0;                     //法术强度
        [SerializeField]
        private int m_PhysicalDfs = 0;                  //物理防御
        [SerializeField]
        private int m_SpellDfs = 0;                     //法术防御

        public ActorData(int entityId, int typeId, CampType camp) : base(entityId, typeId)
        {
            m_Camp = camp;
            m_HP = 0;
            m_SP = 0;
        }

        /// <summary>
        /// 生命值
        /// </summary>
        public int HP { get => m_HP; set => m_HP = Math.Max(0, value); }

        /// <summary>
        /// 最大生命
        /// </summary>
        public abstract int MaxHP
        {
            get;
        }

        /// <summary>
        /// 生命百分比
        /// </summary>
        public float HPRatio
        { 
            get
            {
                return MaxHP > 0 ? (float)HP / MaxHP : 0f;
            }
        }

        /// <summary>
        /// 行动值
        /// </summary>
        public int SP { get => m_SP; set => m_SP = Math.Max(0, value); }

        /// <summary>
        /// 最大行动值
        /// </summary>
        public abstract int MaxSP
        {
            get;
        }

        /// <summary>
        /// 每回合SP的恢复量
        /// </summary>
        public int SPRecovery
        {
            get => MaxSP >> 1 + 2;
        }

        /// <summary>
        /// 行动值百分比
        /// </summary>
        public float SPRatio
        {
            get
            {
                return MaxSP > 0 ? (float)SP / MaxSP : 0f;
            }
        }

        /// <summary>
        /// 先攻
        /// </summary>
        public float Priority { get => m_Priority; set => m_Priority = value; }

        /// <summary>
        /// 阵营
        /// </summary>
        public CampType Camp { get => m_Camp;}
    }
}