using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGGame
{
    public class SkillConfig : IReference
    {
        public int SkillId { private set; get; }
        public string SkillName { private set; get; }
        public string SkillDescription { private set; get; }
        public string AnimationName { private set; get; }
        public float AnimationEventTiming { private set; get; }
        public int Damage01 { private set; get; }
        public int Damage02 { private set; get; }
        public float Distance { private set; get; }
        public Actor Launcher { private set; get; }
        public int SPConsume { private set; get; }
        public int CoolDown { private set; get; }
        public int RestCoolDown { private set; get; }
        public int Buff1Time { private set; get; }
        public int Buff2Time { private set; get; }
        public DRSkillConfig DRSkillConfig { private set; get; }

        public bool CanUse 
        {    
            get
            {
                return RestCoolDown == 0;
            } 
        }
        public SkillConfig(DRSkillConfig dRSkillConfig, Actor Launcher)
        {
            DRSkillConfig = dRSkillConfig;
            this.Launcher = Launcher;
            SkillId = dRSkillConfig.Id;
            SkillName = dRSkillConfig.Name;
            SkillDescription = dRSkillConfig.Description;
            AnimationName = dRSkillConfig.AnimationName;
            AnimationEventTiming = dRSkillConfig.AnimationEventTiming;
            Damage01 = dRSkillConfig.BaseDamage1 + 
                (int)((dRSkillConfig.Damage1AtkAdd * Launcher.ActorData.Atk) / 100) + 
                (int)((dRSkillConfig.Damage1SpellAtkAdd * Launcher.ActorData.SpellAtk) / 100);
            Damage02 = dRSkillConfig.BaseDamage2 + 
                (int)((dRSkillConfig.Damage2AtkAdd * Launcher.ActorData.Atk) / 100) + 
                (int)((dRSkillConfig.Damage2SpellAtkAdd * Launcher.ActorData.SpellAtk) / 100);
            Distance = dRSkillConfig.Distance;
            SPConsume = dRSkillConfig.SpConsume;
            CoolDown = dRSkillConfig.CoolDown;
            Buff1Time = dRSkillConfig.Buff1Time;
            Buff2Time = dRSkillConfig.Buff2Time;
            RestCoolDown = 0;
        }

        /// <summary>
        /// 每次技能使用前调用一次
        /// </summary>
        /// <param name="Launcher"></param>
        public void UpdateSkillConfig(Actor Launcher)
        {
            Damage01 = DRSkillConfig.BaseDamage1 +
                (int)((DRSkillConfig.Damage1AtkAdd * Launcher.ActorData.Atk) / 100) +
                (int)((DRSkillConfig.Damage1SpellAtkAdd * Launcher.ActorData.SpellAtk) / 100);
            Damage02 = DRSkillConfig.BaseDamage2 +
                (int)((DRSkillConfig.Damage2AtkAdd * Launcher.ActorData.Atk) / 100) +
                (int)((DRSkillConfig.Damage2SpellAtkAdd * Launcher.ActorData.SpellAtk) / 100);
            Distance = DRSkillConfig.Distance;
            SPConsume = DRSkillConfig.SpConsume;
        }

        public void EnterCoolDown()
        {
            RestCoolDown = CoolDown;
        }

        /// <summary>
        /// 冷却时间减1回合
        /// </summary>
        public void UpdateRestCoolDown()
        {
            if(RestCoolDown > 0)
            {
                RestCoolDown--;
            }
        }

        /// <summary>
        /// 重置冷却时间
        /// </summary>
        public void ResetCoolDown()
        {
            if(RestCoolDown > 0) 
            {
                RestCoolDown = 0;
            }
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}
