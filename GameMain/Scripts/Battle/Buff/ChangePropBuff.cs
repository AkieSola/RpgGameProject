using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame {
    public enum E_PropType
    {
        speed = 1
    }
    public class ChangePropBuff : Buff
    {
        public override int duringTurn { get; set; }

        E_PropType Type;
        float value;

        public ChangePropBuff(float value, int duringTurn, E_PropType _PropType)
        {
            this.Type = _PropType;
            this.value = value;
            this.duringTurn = duringTurn;
        }

        public override void BuffEffect(Actor Owner)
        {
            
        }

        public override void BuffStart(Actor Owner)
        {
            switch (Type)
            {
                case E_PropType.speed:
                    Owner.ActorData.Speed += value;
                    break;
            }

            GameEntry.Event.Fire(this,ActorPropChangeEventArgs.Create());
        }

        public override void BuffFinish(Actor Owner)
        {
            switch (Type)
            {
                case E_PropType.speed:
                    Owner.ActorData.Speed -= value;
                    break;
            }

            GameEntry.Event.Fire(this, ActorPropChangeEventArgs.Create());
        }
    }
}
