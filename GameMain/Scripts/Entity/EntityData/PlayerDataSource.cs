using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public enum E_AddPointType
    {
        Power = 1,
        Agile = 2,
        Wisdom = 3
    }
    public class PlayerDataSource
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取Player编号。
        /// </summary>
        public int Id
        {
            get
            {
                return m_Id;
            }
            private set
            {
                m_Id = value;
            }
        }

        /// <summary>
        /// 获取姓名。
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取等级。
        /// </summary>
        public int Lv
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取力量。
        /// </summary>
        public int Power
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取敏捷。
        /// </summary>
        public int Agile
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取智力。
        /// </summary>
        public int Wisdom
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取保留的能力点。
        /// </summary>
        public int AbilityPoint
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取武器。
        /// </summary>
        public int Equip1Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取头盔。
        /// </summary>
        public int Equip2Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取胸甲。
        /// </summary>
        public int Equip3Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取臂甲。
        /// </summary>
        public int Equip4Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取腿甲。
        /// </summary>
        public int Equip5Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取戒指。
        /// </summary>
        public int Equip6Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取携带技能1Id。
        /// </summary>
        public int Skill1Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取携带技能2Id。
        /// </summary>
        public int Skill2Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取携带技能3Id。
        /// </summary>
        public int Skill3Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取携带技能4Id。
        /// </summary>
        public int Skill4Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取携带技能5Id。
        /// </summary>
        public int Skill5Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取携带技能6Id。
        /// </summary>
        public int Skill6Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取携带技能7Id。
        /// </summary>
        public int Skill7Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取携带技能8Id。
        /// </summary>
        public int Skill8Id
        {
            get;
            private set;
        }
        public PlayerDataSource() 
        {
        }
        public PlayerDataSource(DRPlayer dRPlayer)
        {
            Id = dRPlayer.Id;
            Name = dRPlayer.Name;
            Lv = dRPlayer.Lv;
            Power = dRPlayer.Power;
            Agile = dRPlayer.Agile;
            Wisdom = dRPlayer.Wisdom;
            AbilityPoint = dRPlayer.AbilityPoint;
            Equip1Id = dRPlayer.Equip1Id;
            Equip2Id = dRPlayer.Equip2Id;
            Equip3Id = dRPlayer.Equip3Id;
            Equip4Id = dRPlayer.Equip4Id;
            Equip5Id = dRPlayer.Equip5Id;
            Equip6Id = dRPlayer.Equip6Id;
            Skill1Id = dRPlayer.Skill1Id;
            Skill2Id = dRPlayer.Skill2Id;
            Skill3Id = dRPlayer.Skill3Id;
            Skill4Id = dRPlayer.Skill4Id;
            Skill5Id = dRPlayer.Skill5Id;
            Skill6Id = dRPlayer.Skill6Id;
            Skill7Id = dRPlayer.Skill7Id;
            Skill8Id = dRPlayer.Skill8Id;
        }

        public void AddPoint(E_AddPointType pointType, int addValue = 1)
        {
            if (AbilityPoint <= 0) 
            {
                return;
            }
            switch (pointType)
            {
                case E_AddPointType.Power:
                    AbilityPoint -= addValue;
                    Power += addValue;
                    break;
                case E_AddPointType.Agile:
                    AbilityPoint -= addValue;
                    Agile += addValue;
                    break;
                case E_AddPointType.Wisdom:
                    AbilityPoint -= addValue;
                    Wisdom += addValue;
                    break;
            }

        }

        public void SubPoint(E_AddPointType pointType, int subValue = 1)
        {
            if (AbilityPoint <= 0)
            {
                return;
            }
            switch (pointType)
            {
                case E_AddPointType.Power:
                    AbilityPoint += subValue;
                    Power -= subValue;
                    break;
                case E_AddPointType.Agile:
                    AbilityPoint += subValue;
                    Agile -= subValue;
                    break;
                case E_AddPointType.Wisdom:
                    AbilityPoint += subValue;
                    Wisdom -= subValue;
                    break;
            }
        }
    }
}