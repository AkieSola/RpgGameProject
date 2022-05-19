using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame {
    public class ChangeHPBuff : Buff
    {
        public override int duringTurn { get; set; }

        int m_Value;
        E_DamageType e_DamageType;

        public ChangeHPBuff(int value, int duringTurn, E_DamageType e_DamageType)
        {
            this.m_Value = value;
            this.duringTurn = duringTurn;
            this.e_DamageType = e_DamageType;
        }

        public override void BuffEffect(Actor Owner)
        {
            Owner.ApplyDamage(null, m_Value, e_DamageType);
        }

        public override void BuffStart(Actor Owner)
        {
        }

        public override void BuffFinish(Actor Owner)
        {
        }
    }
}