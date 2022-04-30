using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGGame
{
    public class SkillConfig
    {
        public int SkillId { private set; get; }
        public string SkillName { private set; get; }
        public int Damage01 { private set; get; }
        public int Damage02 { private set; get; }
        public float Distance { private set; get; }
        public Actor Launcher { private set; get; }
        public int SPConsume { private set; get; }

        public SkillConfig(DRSkillConfig dRSkillConfig, Actor Launcher)
        {
            this.Launcher = Launcher;
            SkillId = dRSkillConfig.Id;
            SkillName = dRSkillConfig.Name;
            Damage01 = dRSkillConfig.BaseDamage1 + 
                (int)((dRSkillConfig.Damage1AtkAdd * Launcher.ActorData.Atk) / 100) + 
                (int)((dRSkillConfig.Damage1SpellAtkAdd * Launcher.ActorData.SpellAtk) / 100);
            Damage02 = dRSkillConfig.BaseDamage2 + 
                (int)((dRSkillConfig.Damage2AtkAdd * Launcher.ActorData.Atk) / 100) + 
                (int)((dRSkillConfig.Damage2SpellAtkAdd * Launcher.ActorData.SpellAtk) / 100);
            Distance = dRSkillConfig.Distance;
            SPConsume = dRSkillConfig.SpConsume;
        }
    }
}
