using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            CloseBtn.onClick.AddListener(() => { GameEntry.UI.CloseUIForm(this); });
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
            CloseBtn.onClick.RemoveAllListeners();
            PowerAddBtn.onClick.RemoveAllListeners();
            AgileAddBtn.onClick.RemoveAllListeners();
            WisdomAddBtn.onClick.RemoveAllListeners();
        }
    }
}
