using GameFramework.DataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame {

    /// <summary>
    /// 包括角色加的点
    /// </summary>
    public class PlayerData : ActorData
    {
        [SerializeField]
        private int m_Id;
        [SerializeField]
        private string m_Name;
        [SerializeField]
        private int m_Lv;        //等级 = 直接增加MaxHP, 增加Atk
        [SerializeField]
        private int m_Power;        //力量 = 增加MaxHP, 增加护甲, 补正力量型武器
        [SerializeField]    
        private int m_Agile;        //敏捷 = 增加先攻,  增加MaxSP, 补正敏捷型武器
        [SerializeField]    
        private int m_Wisdom;       //智力 = 增加法强， 增加魔抗,  补正魔法型武器
        //[SerializeField]
        //private int m_Faith;      
        [SerializeField]
        private int m_AbilityAddPoint;
        [SerializeField]
        private Dictionary<EquipType, DREquip> PlayerEquips;       //角色的装备


        private int baseMaxHP = 100;
        private int baseMaxSP = 10;
        private int baseATK = 10;
        private float m_LvPowAddHP = 1.2f;
        public PlayerData(DRPlayer dRPlayer, int entityId, int typeId) :base(entityId, typeId)
        {
            m_Id = dRPlayer.Id;
            m_Name = dRPlayer.Name;
            m_Lv = dRPlayer.Lv;
            m_Power = dRPlayer.Power;
            m_Agile = dRPlayer.Agile;
            m_Wisdom = dRPlayer.Wisdom;

            IDataTable<DREquip> dtEquip = GameEntry.DataTable.GetDataTable<DREquip>();
            PlayerEquips = new Dictionary<EquipType, DREquip>()
            {
                {EquipType.weapon, dtEquip.GetDataRow(dRPlayer.Equip1Id) },
                {EquipType.helmet, dtEquip.GetDataRow(dRPlayer.Equip2Id) },
                {EquipType.breastplate, dtEquip.GetDataRow(dRPlayer.Equip3Id) },
                {EquipType.gardebras, dtEquip.GetDataRow(dRPlayer.Equip4Id) },
                {EquipType.cuisse, dtEquip.GetDataRow(dRPlayer.Equip5Id) },
                {EquipType.ring, dtEquip.GetDataRow(dRPlayer.Equip6Id) }
            };

            base.ActorId = m_Id;
            base.MaxHP = (int)(baseMaxHP * Mathf.Pow(m_LvPowAddHP, LvPowAddHP) + m_Power * 20); //+装备加成
            base.HP = MaxHP;
            base.SP = MaxSP;
            base.Priority = 5;
            base.MaxSP = baseMaxHP;
            base.Atk = baseATK;
            base.SpellAtk = 0;
            base.AtkDistance = 10.0f;
            base.PhysicsDfs = 0;
            base.SpellDfs = 0;
        }

        public int BaseMaxHP { get => baseMaxHP;}
        public int BaseMaxSP { get => baseMaxSP;}
        public float LvPowAddHP { get => m_LvPowAddHP;}
    }
}
