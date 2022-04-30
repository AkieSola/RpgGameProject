using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    /// <summary>
    /// 小火球
    /// 对目标单位造成伤害，之后会施加一层燃烧的buff，每回合造成伤害
    /// </summary>
    public class Skill001 : TargetSkillLogic
    {

        public override void OnBump(SkillConfig skillConfig, Actor Target)
        {
            throw new System.NotImplementedException();
        }

        public override void OnEnd(SkillConfig skillConfig, Actor Target)
        {
            throw new System.NotImplementedException();
        }

        public override void OnFire(SkillConfig skillConfig, Actor Target)
        {
            throw new System.NotImplementedException();
        }

        public override void OnInit(SkillConfig skillConfig, Actor Target)
        {
            throw new System.NotImplementedException();
        }

        public override void OnLaunch(SkillConfig skillConfig, Actor Target)
        {
            //Actor DoSkill-> 播放动画
            //通过动画事件->生成技能对象
            //技能对象碰撞到Target,对Target产生效果
        }


    }
}
