using GameFramework.Resource;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame
{
    public class SkillItem : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        [SerializeField]
        private Text nameText;
        [SerializeField]
        private Image icon;

        public const String SkillIconNamePerfix = "SkillIcon";
        public void UpdateInfo(Skill skill)
        {
            if (skill == null)
            {
                icon.enabled = false;
                nameText.enabled = false;
                button.enabled = false;
            }
            else
            {
                icon.enabled = true;
                GameEntry.Resource.LoadAsset(GameEntry.Resource.ReadOnlyPath + "/" + SkillIconNamePerfix + "/" + skill.Config.SkillId, new LoadAssetCallbacks(LoadIconSuccess), icon);
                nameText.enabled = true;
                nameText.text = skill.Config.SkillName;
                button.enabled = true;
                button.onClick.RemoveAllListeners();
                //button.onClick.AddListener();
                
            }
        }

        void LoadIconSuccess(string assetName, object asset, float duration, object userData)
        {
            Image image = userData as Image;
            if (asset == null)
            {
                image.enabled = false;
            }
            else
            {
                image.enabled = true;
                image.sprite = (asset as Sprite);
            }
        }
    }
}
