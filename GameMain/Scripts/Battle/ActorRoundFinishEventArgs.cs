using GameFramework;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame {
    public class ActorRoundFinishEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(ActorRoundFinishEventArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public Actor actor
        {
            get;
            private set;
        }

        public static ActorRoundFinishEventArgs Create(Actor actor)
        {
            ActorRoundFinishEventArgs e = ReferencePool.Acquire<ActorRoundFinishEventArgs>();
            e.actor = actor;
            return e;
        }

        public override void Clear()
        {
            actor = null;
        }
    }
}
