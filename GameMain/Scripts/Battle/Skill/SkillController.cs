using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RPGGame
{
    public class SkillController
    {
        public static void SkillLaunch(int SkillId, Actor Launcher, Actor Taget, Vector3 poa)
        {
            //取得Skill数据，得到类型
            DRSkillConfig dRSkillConfig = GameEntry.DataTable.GetDataTable<DRSkillConfig>().GetDataRow(SkillId);
            //类名 = skill + 技能id
            Assembly assembly = Assembly.GetExecutingAssembly();
            object skill = assembly.CreateInstance("类的完全限定名");
            //从引用池中取对象

        }
    }
}
