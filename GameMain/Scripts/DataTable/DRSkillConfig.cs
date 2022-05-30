//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2022-05-30 09:59:18.469
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    /// <summary>
    /// 技能表。
    /// </summary>
    public class DRSkillConfig : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取技能编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取技能名。
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能类型（1.TargetSkill）。
        /// </summary>
        public int Type
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能描述。
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取图标名。
        /// </summary>
        public string Icon
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取动画名。
        /// </summary>
        public string AnimationName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取动画事件触发时机(s)。
        /// </summary>
        public float AnimationEventTiming
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取特效名。
        /// </summary>
        public string EffectName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取范围。
        /// </summary>
        public float Distance
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取基础伤害1。
        /// </summary>
        public int BaseDamage1
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取基础伤害2。
        /// </summary>
        public int BaseDamage2
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取伤害1法术攻击加成*100。
        /// </summary>
        public int Damage1SpellAtkAdd
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取伤害2法术攻击加成*100。
        /// </summary>
        public int Damage2SpellAtkAdd
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取伤害1攻击加成*100。
        /// </summary>
        public int Damage1AtkAdd
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取伤害2攻击加成*100。
        /// </summary>
        public int Damage2AtkAdd
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取SP消耗。
        /// </summary>
        public int SpConsume
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取冷却回合数。
        /// </summary>
        public int CoolDown
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取施加的Buff1持续回合数。
        /// </summary>
        public int Buff1Time
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取施加的Buff2持续回合数。
        /// </summary>
        public int Buff2Time
        {
            get;
            private set;
        }

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnStrings.Length; i++)
            {
                columnStrings[i] = columnStrings[i].Trim(DataTableExtension.DataTrimSeparators);
            }

            int index = 0;
            index++;
            m_Id = int.Parse(columnStrings[index++]);
            index++;
            Name = columnStrings[index++];
            Type = int.Parse(columnStrings[index++]);
            Description = columnStrings[index++];
            Icon = columnStrings[index++];
            AnimationName = columnStrings[index++];
            AnimationEventTiming = float.Parse(columnStrings[index++]);
            EffectName = columnStrings[index++];
            Distance = float.Parse(columnStrings[index++]);
            BaseDamage1 = int.Parse(columnStrings[index++]);
            BaseDamage2 = int.Parse(columnStrings[index++]);
            Damage1SpellAtkAdd = int.Parse(columnStrings[index++]);
            Damage2SpellAtkAdd = int.Parse(columnStrings[index++]);
            Damage1AtkAdd = int.Parse(columnStrings[index++]);
            Damage2AtkAdd = int.Parse(columnStrings[index++]);
            SpConsume = int.Parse(columnStrings[index++]);
            CoolDown = int.Parse(columnStrings[index++]);
            Buff1Time = int.Parse(columnStrings[index++]);
            Buff2Time = int.Parse(columnStrings[index++]);

            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            using (MemoryStream memoryStream = new MemoryStream(dataRowBytes, startIndex, length, false))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                {
                    m_Id = binaryReader.Read7BitEncodedInt32();
                    Name = binaryReader.ReadString();
                    Type = binaryReader.Read7BitEncodedInt32();
                    Description = binaryReader.ReadString();
                    Icon = binaryReader.ReadString();
                    AnimationName = binaryReader.ReadString();
                    AnimationEventTiming = binaryReader.ReadSingle();
                    EffectName = binaryReader.ReadString();
                    Distance = binaryReader.ReadSingle();
                    BaseDamage1 = binaryReader.Read7BitEncodedInt32();
                    BaseDamage2 = binaryReader.Read7BitEncodedInt32();
                    Damage1SpellAtkAdd = binaryReader.Read7BitEncodedInt32();
                    Damage2SpellAtkAdd = binaryReader.Read7BitEncodedInt32();
                    Damage1AtkAdd = binaryReader.Read7BitEncodedInt32();
                    Damage2AtkAdd = binaryReader.Read7BitEncodedInt32();
                    SpConsume = binaryReader.Read7BitEncodedInt32();
                    CoolDown = binaryReader.Read7BitEncodedInt32();
                    Buff1Time = binaryReader.Read7BitEncodedInt32();
                    Buff2Time = binaryReader.Read7BitEncodedInt32();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        private KeyValuePair<int, int>[] m_BaseDamage = null;

        public int BaseDamageCount
        {
            get
            {
                return m_BaseDamage.Length;
            }
        }

        public int GetBaseDamage(int id)
        {
            foreach (KeyValuePair<int, int> i in m_BaseDamage)
            {
                if (i.Key == id)
                {
                    return i.Value;
                }
            }

            throw new GameFrameworkException(Utility.Text.Format("GetBaseDamage with invalid id '{0}'.", id));
        }

        public int GetBaseDamageAt(int index)
        {
            if (index < 0 || index >= m_BaseDamage.Length)
            {
                throw new GameFrameworkException(Utility.Text.Format("GetBaseDamageAt with invalid index '{0}'.", index));
            }

            return m_BaseDamage[index].Value;
        }

        private void GeneratePropertyArray()
        {
            m_BaseDamage = new KeyValuePair<int, int>[]
            {
                new KeyValuePair<int, int>(1, BaseDamage1),
                new KeyValuePair<int, int>(2, BaseDamage2),
            };
        }
    }
}
