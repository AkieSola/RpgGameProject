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
    public class MainCityForm : UGuiForm
    {
        [SerializeField]
        private Slider m_ExpSlider = null;
        [SerializeField]
        private Slider m_HPSlider = null;
        [SerializeField]
        private Text m_HPText = null;
        [SerializeField]
        private Slider m_SPSlider = null;
        [SerializeField]
        private Text m_SPText = null;
        [SerializeField]
        private SkillList m_SkillList = null;
        [SerializeField]
        private Button m_PropBtn = null;
        [SerializeField]
        private Button m_BagBtn = null;
        [SerializeField]
        private Button m_TurnEndBtn = null;

        private ProcedureMain m_ProcedureMain = null;
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_ProcedureMain = (ProcedureMain)userData;

            GameEntry.Event.Subscribe(ActorRoundStartEventArgs.EventId, ShowTurnEndBtn);
            GameEntry.Event.Subscribe(UpdateActorFormInfoArgs.EventId, UpdateActorInfo);
            GameEntry.Event.Subscribe(UpdateSkillInfoEventArges.EventId, UpdateSkillShowInfo);
            GameEntry.Event.Subscribe(LevelBattleEventArgs.EventId, LevelBattle);

            if (m_ProcedureMain == null)
            {
                Log.Warning("ProcedureMain is invalid when open MainCityForm.");
                return;
            }

            m_TurnEndBtn.gameObject.SetActive(false);

            m_HPSlider.value = m_ProcedureMain.PlayerData.HPRatio;
            m_HPText.text = "生命值";

            m_SPSlider.value = m_ProcedureMain.PlayerData.SPRatio;
            m_SPText.text = "行动值";

            m_PropBtn.GetComponentInChildren<Text>().text = "属性";
            m_PropBtn.onClick.AddListener(() => { GameEntry.UI.OpenUIForm(UIFormId.PlayerPropFrom, m_ProcedureMain.PlayerData); });

            m_BagBtn.GetComponentInChildren<Text>().text = "背包";
            m_BagBtn.onClick.AddListener(() => { GameEntry.UI.OpenUIForm(UIFormId.BagFrom, m_ProcedureMain.PlayerData.ItemDic); });

            m_TurnEndBtn.GetComponentInChildren<Text>().text = "回合结束";
            m_TurnEndBtn.onClick.AddListener(() =>
            {
                GameEntry.Event.Fire(this, ActorRoundFinishEventArgs.Create(null));
            });
        }

        private void LevelBattle(object sender, GameEventArgs e)
        {
            LevelBattleEventArgs levelBattleEventArgs = (LevelBattleEventArgs)e;
            if (levelBattleEventArgs != null) 
            {
                m_TurnEndBtn.gameObject.SetActive(false);
            }
        }

        private void UpdateActorInfo(object sender, GameEventArgs e)
        {
            UpdateActorFormInfoArgs ue = e as UpdateActorFormInfoArgs;
            if (ue != null && (sender as Actor).gameObject.tag == "Player")
            {
                Player player = sender as Player;
                m_SPSlider.value = player.ActorData.SPRatio;
                m_HPSlider.value = player.ActorData.HPRatio;
            }
        }

        private void UpdateSkillShowInfo(object sender, GameEventArgs e)
        {
            Actor actor = sender as Actor;
            if (actor is Player)
            {
                m_SkillList.UpdateInfo((e as UpdateSkillInfoEventArges).SkillList);
            }
        }

        private void ShowTurnEndBtn(object sender, GameEventArgs e)
        {
            if (e is ActorRoundStartEventArgs)
            {
                if ((e as ActorRoundStartEventArgs).actor is Player)
                {
                    m_TurnEndBtn.gameObject.SetActive(true);
                    m_TurnEndBtn.enabled = true;
                }
                else
                {
                    m_TurnEndBtn.gameObject.SetActive(false);
                }
            }
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            m_ProcedureMain = null;

            base.OnClose(isShutdown, userData);
        }
    }

    public class UpdateActorFormInfoArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UpdateActorFormInfoArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public static UpdateActorFormInfoArgs Create()
        {
            UpdateActorFormInfoArgs e = ReferencePool.Acquire<UpdateActorFormInfoArgs>();
            return e;
        }

        public override void Clear()
        {
        }
    }

    public class UpdateSkillInfoEventArges : GameEventArgs
    {
        public static readonly int EventId = typeof(UpdateSkillInfoEventArges).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public List<Skill> SkillList;

        public static UpdateSkillInfoEventArges Create(List<Skill> SkillList)
        {
            UpdateSkillInfoEventArges e = ReferencePool.Acquire<UpdateSkillInfoEventArges>();
            e.SkillList = SkillList;
            return e;
        }

        public override void Clear()
        {
            SkillList = null;
        }
    }
}
