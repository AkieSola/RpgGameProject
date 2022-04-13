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
        private string m_Lv;        //等级 = 直接增加MaxHP, 增加Atk
        [SerializeField]
        private int m_Power;        //力量 = 增加MaxHP, 增加护甲, 补正力量型武器
        [SerializeField]    
        private int m_Agile;        //敏捷 = 增加先攻,  增加MaxSP, 补正敏捷型武器
        [SerializeField]    
        private int m_Wisdom;       //智力 = 增加法强， 增加魔抗,  补正魔法型武器
        //[SerializeField]
        //private int m_Faith;      
        [SerializeField]
        private Dictionary<EquipType, Equip> PlayerEquips;       //角色的装备

        public PlayerData(DRPlayer dRPlayer, int entityId, int typeId) :base(entityId, typeId)
        {

        }
    }
}
