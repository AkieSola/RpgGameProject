using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    /// <summary>
    /// 小火球
    /// 对目标单位造成伤害，之后会施加一层燃烧的buff，每回合造成伤害
    /// </summary>
    public class Skill001 : Skill
    {
        public override void OnInit()
        {
           
        }

        public override void OnLaunch()
        {
            base.OnLaunch();
            Config.Launcher.DoSkill(Config);
        }

        public override void OnFire(object sender, GameEventArgs e)
        {
            base.OnFire(sender, e);
            
            SkillFireEventArgs skillFireEventArgs = (SkillFireEventArgs)e;

            if (skillFireEventArgs != null && skillFireEventArgs.skill == this)
            {
                GameEntry.Entity.ShowSkillBall(new SkillBallObjData(GameEntry.Entity.GenerateSerialId(), 60001, 5f, this)
                {
                    Position = Config.Launcher.transform.position
                });
            }
        }

        public override void OnBump()
        {
            base.OnBump();
            //激发特效
            //造成伤害
            Target.ApplyDamage(Config.Launcher, Config.Damage01, E_DamageType.Spell);
            OnEnd();
        }
    }
}
