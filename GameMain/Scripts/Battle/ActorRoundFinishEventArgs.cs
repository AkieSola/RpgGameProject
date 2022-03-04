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

        public int ActorId
        {
            get;
            private set;
        }

        public static ActorRoundFinishEventArgs Create(int id)
        {
            ActorRoundFinishEventArgs e = ReferencePool.Acquire<ActorRoundFinishEventArgs>();
            e.ActorId = id;
            return e;
        }

        public override void Clear()
        {
            ActorId = -1;
        }
    }
}
