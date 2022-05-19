using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Skill002 : Skill
    {
        public override void OnInit()
        {
            base.OnInit();
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
                GameEntry.Entity.ShowSkillBall(new SkillBallObjData(GameEntry.Entity.GenerateSerialId(), 60001, 10f, this)
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

        public override void OnEnd()
        {
            Config.Launcher.EndDoSkill();
            Target.BuffContainer.AddBuff(new ChangeHPBuff(Config.Damage02, Config.Buff1Time, E_DamageType.Spell));
            GameEntry.Event.Unsubscribe(SkillFireEventArgs.EventId, OnFire);
            base.OnEnd();
        }
    }
}
