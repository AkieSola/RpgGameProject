//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2022-05-30 09:59:18.450
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
    /// 装备表。
    /// </summary>
    public class DREquip : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取装备ID。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取装备姓名。
        /// </summary>
        public string EquipName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取装备描述。
        /// </summary>
        public string EquipDescription
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取资源名称。
        /// </summary>
        public string EquipPath
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取物理攻击加成。
        /// </summary>
        public int PhysicsAttack
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取法术强度加成。
        /// </summary>
        public int SpellAttack
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取物理抗性加成。
        /// </summary>
        public int PhysicsDefense
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取魔法抗性加成。
        /// </summary>
        public int SpellDefense
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取力量补正.* 10。
        /// </summary>
        public int PowerAdd
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取敏捷补正 * 10。
        /// </summary>
        public int AgileAdd
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取智力补正 *10。
        /// </summary>
        public int WisdomAdd
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取装备等级要求。
        /// </summary>
        public int Level
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取装备类型 。
        /// </summary>
        public int EquipType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取装备子类型。
        /// </summary>
        public int SubEquipType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取稀有度。
        /// </summary>
        public int EquipRare
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
            EquipName = columnStrings[index++];
            EquipDescription = columnStrings[index++];
            EquipPath = columnStrings[index++];
            PhysicsAttack = int.Parse(columnStrings[index++]);
            SpellAttack = int.Parse(columnStrings[index++]);
            PhysicsDefense = int.Parse(columnStrings[index++]);
            SpellDefense = int.Parse(columnStrings[index++]);
            PowerAdd = int.Parse(columnStrings[index++]);
            AgileAdd = int.Parse(columnStrings[index++]);
            WisdomAdd = int.Parse(columnStrings[index++]);
            Level = int.Parse(columnStrings[index++]);
            EquipType = int.Parse(columnStrings[index++]);
            SubEquipType = int.Parse(columnStrings[index++]);
            EquipRare = int.Parse(columnStrings[index++]);

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
                    EquipName = binaryReader.ReadString();
                    EquipDescription = binaryReader.ReadString();
                    EquipPath = binaryReader.ReadString();
                    PhysicsAttack = binaryReader.Read7BitEncodedInt32();
                    SpellAttack = binaryReader.Read7BitEncodedInt32();
                    PhysicsDefense = binaryReader.Read7BitEncodedInt32();
                    SpellDefense = binaryReader.Read7BitEncodedInt32();
                    PowerAdd = binaryReader.Read7BitEncodedInt32();
                    AgileAdd = binaryReader.Read7BitEncodedInt32();
                    WisdomAdd = binaryReader.Read7BitEncodedInt32();
                    Level = binaryReader.Read7BitEncodedInt32();
                    EquipType = binaryReader.Read7BitEncodedInt32();
                    SubEquipType = binaryReader.Read7BitEncodedInt32();
                    EquipRare = binaryReader.Read7BitEncodedInt32();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        private void GeneratePropertyArray()
        {

        }
    }
}
