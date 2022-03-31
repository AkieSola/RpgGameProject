using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class StoryGame : GameBase
    {
        public override GameMode GameMode
        { 
            get
            {
                return GameMode.Story;
            }
        }
    }
}
