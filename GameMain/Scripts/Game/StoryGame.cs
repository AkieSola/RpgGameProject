using GameFramework;
using GameFramework.DataTable;
using GameFramework.Entity;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class StoryGame : GameBase
    {
        private float m_ElapseSeconds = 0;
        public override GameMode GameMode
        { 
            get
            {
                return GameMode.Story;
            }
        }

        

        protected override void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            base.OnShowEntitySuccess(sender, e);
        }
        protected override void OnShowEntityFailure(object sender, GameEventArgs e)
        {
            base.OnShowEntityFailure(sender, e);
        }
    }
}
