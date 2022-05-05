using GameFramework;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RPGGame
{
    public class SkillFactor
    {
        public static Skill CreateSkill(int SkillId, Actor Launcher)
        {
            if(SkillId <= 0)
            {
                return null;
            }

            DRSkillConfig dRSkillConfig = GameEntry.DataTable.GetDataTable<DRSkillConfig>().GetDataRow(SkillId);

            Assembly assembly = Assembly.GetExecutingAssembly();
            Skill skill = assembly.CreateInstance("RPGGame.Skill00" + SkillId) as Skill;
            
            //技能初始化
            skill.Init(dRSkillConfig, Launcher);
            return skill;
        }
    }
}
