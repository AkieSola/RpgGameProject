using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff
{
    public abstract int duringTurn { get; set; }

    public virtual void BuffStart() { }

    public abstract void BuffEffect();

    public virtual void BuffFinish() { }
}
