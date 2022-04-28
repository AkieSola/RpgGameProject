using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public abstract class SelectSkill : ISkill
    {
        public int SkillId { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Init(DRSkillConfig dRSkillConfig)
        {
            throw new System.NotImplementedException();
        }

        public abstract void Launch(Actor actor);
    }
}
