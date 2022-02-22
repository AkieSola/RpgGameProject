using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public abstract class ActorData : EntityData
    {
        [SerializeField]        
        private int m_ID = 0;                           //角色ID
        [SerializeField]                                
        private int m_HP = 0;                           //生命值
        [SerializeField]
        private int m_SP = 0;                           //行动值
        [SerializeField]
        private float m_Priority = 0;                   //先攻值
        [SerializeField]
        private CampType m_Camp = CampType.Unknown;     //阵营

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