using GameFramework;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public class SkillBallObj : Entity
    {
        [SerializeField]
        private SkillBallObjData skillObjData = null;
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            skillObjData = userData as SkillBallObjData;
            if(skillObjData == null)
            {
                Log.Error("SkillObjData is invalid!");
            }
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if(skillObjData.Skill.Target != null)
            {
                if(other.GetComponent<Actor>() == skillObjData.Skill.Target)
                {

                    skillObjData.Skill.OnBump();
                    GameEntry.Entity.HideEntity(this.Entity.Id);
                }
            }
        }

        protected override void OnRecycle()
        {
            base.OnRecycle();
        }
    }
}

public class SkillBumpEventArgs : GameEventArgs
{
    public static readonly int EventId = typeof(SkillBumpEventArgs).GetHashCode();

    public override int Id
    {
        get
        {
            return EventId;
        }
    }



    public static SkillBumpEventArgs Create()
    {
        SkillBumpEventArgs e = ReferencePool.Acquire<SkillBumpEventArgs>();
        return e;
    }

    public override void Clear()
    {
    }
}
