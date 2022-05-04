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
            GameEntry.Event.Subscribe(SkillFireEventArgs.EventId, OnFire);
        }

        private void OnFire(object sender, GameEventArgs e)
        {
            //生成对象
            string path = GameEntry.Resource.ReadWritePath;
            ;
        }

        public override void OnBump()
        {
            throw new System.NotImplementedException();
        }

        public override void OnEnd()
        {
            throw new System.NotImplementedException();
        }

        public override void OnFire()
        {
            throw new System.NotImplementedException();
        }



        public override void OnLaunch()
        {
            Config.Launcher.DoSkill(Config);
        }
    }
}
