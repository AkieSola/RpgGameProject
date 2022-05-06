using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public abstract class Buff
    {
        public abstract int duringTurn { get; set; }

        public virtual void BuffStart() { }

        public abstract void BuffEffect(Actor Owner);

        public virtual void BuffFinish() { }
    }
}
