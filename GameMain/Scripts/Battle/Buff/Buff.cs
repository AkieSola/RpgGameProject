using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public abstract class Buff
    {
        public abstract int duringTurn { get; set; }

        public abstract void BuffStart(Actor Owner);

        public abstract void BuffEffect(Actor Owner);

        public abstract void BuffFinish(Actor Owner);
    }
}
