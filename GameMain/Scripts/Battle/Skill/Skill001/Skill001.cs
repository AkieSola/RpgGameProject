using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    /// <summary>
    /// С����
    /// ��Ŀ�굥λ����˺���֮���ʩ��һ��ȼ�յ�buff��ÿ�غ�����˺�
    /// </summary>
    public class Skill001 : Skill
    {
        public override void OnInit()
        {
            GameEntry.Event.Subscribe(SkillFireEventArgs.EventId, OnFire);
        }

        public override void OnLaunch()
        {
            Config.Launcher.DoSkill(Config);
        }

        public override void OnFire(object sender, GameEventArgs e)
        {
            base.OnFire(sender, e);
            GameEntry.Entity.ShowSkillBall(new SkillBallObjData(GameEntry.Entity.GenerateSerialId(), 60001, 5f, this)
            {
                Position = Config.Launcher.transform.position
            });
        }

        public override void OnBump()
        {
            base.OnBump();
            //������Ч
            //����˺�
            Target.ApplyDamage(Config.Launcher, Config.Damage01, E_DamageType.Spell);
            OnEnd();
        }

        public override void OnEnd()
        {
            Config.Launcher.EndDoSkill();
            GameEntry.Event.Unsubscribe(SkillFireEventArgs.EventId, OnFire);
            base.OnEnd();
        }
    }
}