using GameFramework;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public sealed class ActorRoundStartEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(ActorRoundStartEventArgs).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public Actor actor;

        public static ActorRoundStartEventArgs Create(Actor actor)
        {
            ActorRoundStartEventArgs e = ReferencePool.Acquire<ActorRoundStartEventArgs>();
            e.actor = actor;
            return e;
        } 

        public override void Clear()
        {
            actor = null;
        }
    }
}
