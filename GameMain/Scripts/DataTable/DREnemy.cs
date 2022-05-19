//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2022-05-19 19:05:39.808
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
    /// Enemy表。
    /// </summary>
    public class DREnemy : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取Enemy编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
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
        /// 获取掉落Id。
        /// </summary>
        public int DropId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取AIId。
        /// </summary>
        public int AIId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取最大生命。
        /// </summary>
        public int MaxHp
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取最大Sp。
        /// </summary>
        public int MaxSp
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取先攻。
        /// </summary>
        public int Priority
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取攻击力。
        /// </summary>
        public int Atk
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取法术强度。
        /// </summary>
        public int SpellAtk
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取攻击距离。
        /// </summary>
        public int AtkDistance
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取物抗。
        /// </summary>
        public int PhysicsDfs
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取魔抗。
        /// </summary>
        public int SpellDfs
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
            Lv = int.Parse(columnStrings[index++]);
            DropId = int.Parse(columnStrings[index++]);
            AIId = int.Parse(columnStrings[index++]);
            MaxHp = int.Parse(columnStrings[index++]);
            MaxSp = int.Parse(columnStrings[index++]);
            Priority = int.Parse(columnStrings[index++]);
            Atk = int.Parse(columnStrings[index++]);
            SpellAtk = int.Parse(columnStrings[index++]);
            AtkDistance = int.Parse(columnStrings[index++]);
            PhysicsDfs = int.Parse(columnStrings[index++]);
            SpellDfs = int.Parse(columnStrings[index++]);

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
                    Lv = binaryReader.Read7BitEncodedInt32();
                    DropId = binaryReader.Read7BitEncodedInt32();
                    AIId = binaryReader.Read7BitEncodedInt32();
                    MaxHp = binaryReader.Read7BitEncodedInt32();
                    MaxSp = binaryReader.Read7BitEncodedInt32();
                    Priority = binaryReader.Read7BitEncodedInt32();
                    Atk = binaryReader.Read7BitEncodedInt32();
                    SpellAtk = binaryReader.Read7BitEncodedInt32();
                    AtkDistance = binaryReader.Read7BitEncodedInt32();
                    PhysicsDfs = binaryReader.Read7BitEncodedInt32();
                    SpellDfs = binaryReader.Read7BitEncodedInt32();
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
