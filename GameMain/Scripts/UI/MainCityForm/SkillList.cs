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
        private SkillItem Skill1;
        [SerializeField]
        private SkillItem Skill2;
        [SerializeField]
        private SkillItem Skill3;
        [SerializeField]
        private SkillItem Skill4;
        [SerializeField]
        private SkillItem Skill5;
        [SerializeField]
        private SkillItem Skill6;
        [SerializeField]
        private SkillItem Skill7;
        [SerializeField]
        private SkillItem Skill8;

        

        public void UpdateInfo(List<Skill> SkillList)
        {
            Skill1.UpdateInfo(SkillList[0]);
            Skill2.UpdateInfo(SkillList[1]);
            Skill3.UpdateInfo(SkillList[2]);
            Skill4.UpdateInfo(SkillList[3]);
            Skill5.UpdateInfo(SkillList[4]);
            Skill6.UpdateInfo(SkillList[5]);
            Skill7.UpdateInfo(SkillList[6]);
            Skill8.UpdateInfo(SkillList[7]);
        }
    }
}