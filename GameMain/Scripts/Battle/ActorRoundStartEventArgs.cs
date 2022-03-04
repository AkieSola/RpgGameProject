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
        
        public int ActorId
        {
            get;
            private set;
        }

        public static ActorRoundStartEventArgs Create(int id)
        {
            ActorRoundStartEventArgs e = ReferencePool.Acquire<ActorRoundStartEventArgs>();
            e.ActorId = id;
            return e;
        } 

        public override void Clear()
        {
            ActorId = -1;
        }
    }
}
