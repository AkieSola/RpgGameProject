using GameFramework;
using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public class PlayerPropForm : UGuiForm
    {
        [SerializeField]
        private Text NameText;
        [SerializeField]
        private Text LVText;
        [SerializeField]
        private Text PowerText;
        [SerializeField]
        private Text AgileText;
        [SerializeField]
        private Text WisdomText;
        [SerializeField]
        private Text AbilityPointText;
        [SerializeField]
        private Text ATKText;
        [SerializeField]
        private Text SpellATKText;
        [SerializeField]
        private Text MaxHPText;
        [SerializeField]
        private Text MaxSPText;
        [SerializeField]
        private Text PhysicsDfsText;
        [SerializeField]
        private Text SpellDfsText;
        [SerializeField]
        private Text PriorityText;
        [SerializeField]
        private Button PowerAddBtn;
        [SerializeField]
        private Button AgileAddBtn;
        [SerializeField]
        private Button WisdomAddBtn;
        [SerializeField]
        private Button CloseBtn;
        [SerializeField]
        private Text WeaponTitle;
        [SerializeField]
        private Image WeaponIcon;
        [SerializeField]
        private Text WeaponATKText;
        [SerializeField]
        private Text WeaponSpellText;
        [SerializeField]
        private Text ArmorTitle;
        [SerializeField]
        private Image ArmorIcon;
        [SerializeField]
        private Text ArmorPhysicsDfsText;
        [SerializeField]
        private Text ArmorSpellDfsText;

        private EventComponent eventComponent;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            eventComponent = GameEntry.Event;
            eventComponent.Subscribe(PlayerAddAbilityPointDataEventArgs.EventId, OnAddAbilityPoint);

            WeaponTitle.text = "装备武器";
            ArmorTitle.text = "装备护甲";
        }

        private void OnAddAbilityPoint(object sender, GameEventArgs e)
        {
            if (e != null && e is PlayerAddAbilityPointFormEventArgs) 
            {
                PlayerData userData = (e as PlayerAddAbilityPointFormEventArgs).playerData;

                if (userData != null)
                {
                    PlayerData pd = userData as PlayerData;
                    CloseBtn.onClick.AddListener(() => { GameEntry.UI.CloseUIForm(this); });
                    NameText.text = GameEntry.Localization.GetString("Prop.Name") + " " + pd.Name;
                    LVText.text = GameEntry.Localization.GetString("Prop.LV") + " " + pd.Lv;
                    PowerText.text = GameEntry.Localization.GetString("Prop.Power") + " " + pd.Power;
                    AgileText.text = GameEntry.Localization.GetString("Prop.Agile") + " " + pd.Agile;
                    WisdomText.text = GameEntry.Localization.GetString("Prop.Wisdom") + " " + pd.Wisdom;
                    AbilityPointText.text = GameEntry.Localization.GetString("Prop.AbilityPoint") + " " + pd.AbilityAddPoint;
                    ATKText.text = GameEntry.Localization.GetString("Prop.ATK") + " " + (pd as ActorData).Atk;
                    SpellATKText.text = GameEntry.Localization.GetString("Prop.SpellATK") + " " + (pd as ActorData).SpellAtk;
                    MaxHPText.text = GameEntry.Localization.GetString("Prop.MaxHP") + " " + (pd as ActorData).MaxHP;
                    MaxSPText.text = GameEntry.Localization.GetString("Prop.MaxSP") + " " + (pd as ActorData).MaxSP;
                    PhysicsDfsText.text = GameEntry.Localization.GetString("Prop.PhysicsDfs") + " " + (pd as ActorData).PhysicsDfs;
                    SpellDfsText.text = GameEntry.Localization.GetString("Prop.SpellDfs") + " " + (pd as ActorData).SpellDfs;
                    PriorityText.text = GameEntry.Localization.GetString("Prop.Priority") + " " + (pd as ActorData).Priority;


                    if (pd.PlayerEquips[EquipType.weapon] != null)
                    {
                        WeaponIcon.sprite = Resources.Load<Sprite>("ItemIcon/" + pd.PlayerEquips[EquipType.weapon].Id);
                    }
                    WeaponATKText.text = "ATK: " + pd.WeaponATK;
                    WeaponSpellText.text = "Spell: " + pd.WeaponSpell;
                    if (pd.PlayerEquips[EquipType.breastplate] != null)
                    {
                        ArmorIcon.sprite = Resources.Load<Sprite>("ItemIcon/" + pd.PlayerEquips[EquipType.breastplate].Id);
                    }
                    ArmorPhysicsDfsText.text = "PhysicsDfs: " + pd.ArmorDfs;
                    ArmorSpellDfsText.text = "SpellDfs: " + pd.ArmorSpellDfs;
                }
            }
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            if (userData != null)
            {
                PlayerData pd = userData as PlayerData;
                CloseBtn.onClick.AddListener(() => { GameEntry.UI.CloseUIForm(this); });
                NameText.text = GameEntry.Localization.GetString("Prop.Name") + " " + pd.Name;
                LVText.text = GameEntry.Localization.GetString("Prop.LV") + " " + pd.Lv;
                PowerText.text = GameEntry.Localization.GetString("Prop.Power") + " " + pd.Power;
                AgileText.text = GameEntry.Localization.GetString("Prop.Agile") + " " + pd.Agile;
                WisdomText.text = GameEntry.Localization.GetString("Prop.Wisdom") + " " + pd.Wisdom;
                AbilityPointText.text = GameEntry.Localization.GetString("Prop.AbilityPoint") + " " + pd.AbilityAddPoint;
                ATKText.text = GameEntry.Localization.GetString("Prop.ATK") + " " + (pd as ActorData).Atk;
                SpellATKText.text = GameEntry.Localization.GetString("Prop.SpellATK") + " " + (pd as ActorData).SpellAtk;
                MaxHPText.text = GameEntry.Localization.GetString("Prop.MaxHP") + " " + (pd as ActorData).MaxHP;
                MaxSPText.text = GameEntry.Localization.GetString("Prop.MaxSP") + " " + (pd as ActorData).MaxSP;
                PhysicsDfsText.text = GameEntry.Localization.GetString("Prop.PhysicsDfs") + " " + (pd as ActorData).PhysicsDfs;
                SpellDfsText.text = GameEntry.Localization.GetString("Prop.SpellDfs") + " " + (pd as ActorData).SpellDfs;
                PriorityText.text = GameEntry.Localization.GetString("Prop.Priority") + " " + (pd as ActorData).Priority;

                if (pd.PlayerEquips[EquipType.weapon] != null)
                {
                    WeaponIcon.sprite = Resources.Load<Sprite>("ItemIcon/" + pd.PlayerEquips[EquipType.weapon].Id);
                }
                WeaponATKText.text = "ATK: " + pd.WeaponATK;
                WeaponSpellText.text = "Spell: " + pd.WeaponSpell;
                if (pd.PlayerEquips[EquipType.breastplate] != null)
                {
                    ArmorIcon.sprite = Resources.Load<Sprite>("ItemIcon/" + pd.PlayerEquips[EquipType.breastplate].Id);
                }
                ArmorPhysicsDfsText.text = "PhysicsDfs: " + pd.ArmorDfs;
                ArmorSpellDfsText.text = "SpellDfs: " + pd.ArmorSpellDfs;
            }

            PowerAddBtn.onClick.AddListener(()=> 
            { 
                eventComponent.Fire(this, PlayerAddAbilityPointDataEventArgs.Create(E_AddPointType.Power)); 
            });

            AgileAddBtn.onClick.AddListener(() =>
            {
                eventComponent.Fire(this, PlayerAddAbilityPointDataEventArgs.Create(E_AddPointType.Agile));
            });

            WisdomAddBtn.onClick.AddListener(() =>
            {
                eventComponent.Fire(this, PlayerAddAbilityPointDataEventArgs.Create(E_AddPointType.Wisdom));
            });
        }


        protected override void OnClose(bool isShutdown, object userData)
        {
           
            CloseBtn.onClick.RemoveAllListeners();
            PowerAddBtn.onClick.RemoveAllListeners();
            AgileAddBtn.onClick.RemoveAllListeners();
            WisdomAddBtn.onClick.RemoveAllListeners();

            base.OnClose(isShutdown, userData);
        }
    }


    public class PlayerAddAbilityPointDataEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(PlayerAddAbilityPointDataEventArgs).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public E_AddPointType pointType;
        public int value;

        public PlayerAddAbilityPointDataEventArgs()
        {
        }

        public static PlayerAddAbilityPointDataEventArgs Create(E_AddPointType pointType, int value = 1)
        {
            PlayerAddAbilityPointDataEventArgs playerAddAbilityPointEventArgs = ReferencePool.Acquire<PlayerAddAbilityPointDataEventArgs>();
            playerAddAbilityPointEventArgs.pointType = pointType;
            playerAddAbilityPointEventArgs.value = value;
            return playerAddAbilityPointEventArgs;
        }

        public override void Clear()
        {
        }
    }

    public class PlayerAddAbilityPointFormEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(PlayerAddAbilityPointDataEventArgs).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public PlayerData playerData;

        public PlayerAddAbilityPointFormEventArgs()
        {
        }

        public static PlayerAddAbilityPointFormEventArgs Create(PlayerData playerData)
        {
            PlayerAddAbilityPointFormEventArgs e = ReferencePool.Acquire<PlayerAddAbilityPointFormEventArgs>();
            e.playerData = playerData;
            return e;
        }

        public override void Clear()
        {
            playerData = null;
        }
    }
}

