using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class SkillBallObjData : EntityData
    {
        Skill m_Skill;
        float m_Speed;
        public SkillBallObjData(int entityId, int typeId, float speed, Skill skill) : base(entityId, typeId)
        {
            m_Skill = skill;
            m_Speed = speed;
        }

        public Skill Skill { get => m_Skill;  }
        public float Speed { get => m_Speed; }
    }
}