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
    public class SkillList : MonoBehaviour
    {
        [SerializeField]
        private Image Skill1;
        [SerializeField]
        private Image Skill2;
        [SerializeField]
        private Image Skill3;
        [SerializeField]
        private Image Skill4;
        [SerializeField]
        private Image Skill5;
        [SerializeField]
        private Image Skill6;
        [SerializeField]
        private Image Skill7;
        [SerializeField]
        private Image Skill8;

        

        public void UpdateInfo(List<int> SkillIdList)
        {
            if (SkillIdList != null)
            {
                if (SkillIdList[0] == 0)
                {
                    Skill1.enabled = false;
                    
                }
                else
                {
                    ///加载资源
                    ///把资源放入对象池
                    //GameEntry.Resource.LoadAsset(GameEntry.Resource.ReadOnlyPath + "/" + SkillIconNamePerfix + "/" + SkillIdList[0], new LoadAssetCallbacks(LoadIconSuccess), Skill1);
                }
                if (SkillIdList[1] == 0)
                {
                    Skill2.enabled = false;
                }
                else
                {

                }
                if (SkillIdList[2] == 0)
                {
                    Skill3.enabled = false;
                }
                else
                {

                }
                if (SkillIdList[3] == 0)
                {
                    Skill4.enabled = false;
                }
                else
                {

                }
                if (SkillIdList[4] == 0)
                {
                    Skill5.enabled = false;
                }
                else
                {

                }
                if (SkillIdList[5] == 0)
                {
                    Skill6.enabled = false;
                }
                else
                {

                }
                if (SkillIdList[6] == 0)
                {
                    Skill7.enabled = false;
                }
                else
                {

                }
                if (SkillIdList[7] == 0)
                {
                    Skill8.enabled = false;
                }
                else
                {

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


}