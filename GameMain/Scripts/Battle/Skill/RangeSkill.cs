using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public abstract class RangeSkill : ISkill
    {
        public int SkillId { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Init(DRSkillConfig dRSkillConfig)
        {
            throw new System.NotImplementedException();
        }

        public abstract void Launch(Vector3 position);
    }
}
