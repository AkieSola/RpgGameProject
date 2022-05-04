﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2022-05-01 22:44:58.441
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
    /// 战机表。
    /// </summary>
    public class DRPlayer : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取Player编号。
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
            Power = int.Parse(columnStrings[index++]);
            Agile = int.Parse(columnStrings[index++]);
            Wisdom = int.Parse(columnStrings[index++]);
            AbilityPoint = int.Parse(columnStrings[index++]);
            Equip1Id = int.Parse(columnStrings[index++]);
            Equip2Id = int.Parse(columnStrings[index++]);
            Equip3Id = int.Parse(columnStrings[index++]);
            Equip4Id = int.Parse(columnStrings[index++]);
            Equip5Id = int.Parse(columnStrings[index++]);
            Equip6Id = int.Parse(columnStrings[index++]);

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
                    Power = binaryReader.Read7BitEncodedInt32();
                    Agile = binaryReader.Read7BitEncodedInt32();
                    Wisdom = binaryReader.Read7BitEncodedInt32();
                    AbilityPoint = binaryReader.Read7BitEncodedInt32();
                    Equip1Id = binaryReader.Read7BitEncodedInt32();
                    Equip2Id = binaryReader.Read7BitEncodedInt32();
                    Equip3Id = binaryReader.Read7BitEncodedInt32();
                    Equip4Id = binaryReader.Read7BitEncodedInt32();
                    Equip5Id = binaryReader.Read7BitEncodedInt32();
                    Equip6Id = binaryReader.Read7BitEncodedInt32();
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
