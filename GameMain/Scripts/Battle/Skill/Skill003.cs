using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    /// <summary>
    /// ·ÉÃ«ÍÈ
    /// </summary>
    public class Skill003 : Skill
    {
        public override void OnLaunch()
        {
            base.OnLaunch();
            Config.Launcher.DoSkill(Config);
        }

        public override void OnFire(object sender, GameEventArgs e)
        {
            base.OnFire(sender, e);
            Target.BuffContainer.AddBuff(new ChangePropBuff(5f, 2, E_PropType.speed));
            OnEnd();
        }
    }
}
