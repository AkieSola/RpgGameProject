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
        private int Index;

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
                button.onClick.AddListener(() =>
                {
                    GameEntry.Event.Fire(this, SelectedSkillEventArgs.Create(Index));
                });
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

        public int SkillIdx;

        public static SelectedSkillEventArgs Create(int skillIdx)
        {
            SelectedSkillEventArgs e = ReferencePool.Acquire<SelectedSkillEventArgs>();
            e.SkillIdx = skillIdx;
            return e;
        }

        public override void Clear()
        {
            SkillIdx = -1;
        }
    }

}
