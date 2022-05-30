using GameFramework;
using GameFramework.Event;
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
        [SerializeField]
        private Text CoolDownRestText;
        [SerializeField]
        private Image Mask;
        [SerializeField]
        private int Index;

        public const String SkillIconNamePerfix = "SkillIcon";
        public void UpdateInfo(Skill skill)
        {
            if (skill == null)
            {
                icon.enabled = false;
                nameText.enabled = false;
                button.enabled = false;
                CoolDownRestText.enabled = false;
            }
            else
            {
                icon.enabled = true;
                //GameEntry.Resource.LoadAsset("SkillIcon/" + skill.Config.SkillId, new LoadAssetCallbacks(LoadIconSuccess), icon);
                Sprite sprite = Resources.Load<Sprite>("SkillIcon/" + skill.Config.SkillId.ToString());
                    
                if(sprite == null) 
                {
                    icon.enabled = false;
                }
                else
                {
                    icon.enabled = true;
                    icon.sprite = sprite;
                }

                nameText.enabled = true;
                nameText.text = skill.Config.SkillName;
                button.enabled = true;
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    GameEntry.Event.Fire(this, SelectedSkillEventArgs.Create(skill));
                });

                if (skill.Config.RestCoolDown > 0)
                {
                    CoolDownRestText.enabled = true;
                    CoolDownRestText.text = skill.Config.RestCoolDown.ToString();
                    Mask.enabled = true;
                }
                else
                {
                    CoolDownRestText.enabled = false;
                    Mask.enabled = false;
                }
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

    public class SelectedSkillEventArgs : GameEventArgs
    {
        public static int EventId = typeof(SelectedSkillEventArgs).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public Skill skill;

        public static SelectedSkillEventArgs Create(Skill skill)
        {
            SelectedSkillEventArgs e = ReferencePool.Acquire<SelectedSkillEventArgs>();
            e.skill = skill;
            return e;
        }

        public override void Clear()
        {
            skill = null;
        }
    }

}
