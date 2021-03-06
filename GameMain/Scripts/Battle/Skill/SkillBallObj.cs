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

        float Distance;
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            skillObjData = userData as SkillBallObjData;
            if(skillObjData == null)
            {
                Log.Error("SkillObjData is invalid!");
            }

            
        }

        void Update()
        {
            transform.position += skillObjData.Speed * skillObjData.Skill.ForwardDir * Time.deltaTime;
            Distance = Vector3.Distance(transform.position, skillObjData.Skill.Target.transform.position);
            if (Distance < 3f) 
            {
                GameEntry.Entity.HideEntity(this.Entity.Id);
                skillObjData.Skill.OnBump();
            }
        }

        private void FixedUpdate()
        {
            
        }
        //private void OnTriggerEnter(Collider other)
        //{
        //    if(skillObjData.Skill.Target != null)
        //    {
        //        if(other.GetComponent<Actor>() == skillObjData.Skill.Target)
        //        {

        //        }
        //    }
        //}

        protected override void OnRecycle()
        {
            skillObjData = null;
        }
    }
}

//public class SkillBumpEventArgs : GameEventArgs
//{
//    public static readonly int EventId = typeof(SkillBumpEventArgs).GetHashCode();

//    public override int Id
//    {
//        get
//        {
//            return EventId;
//        }
//    }

//    public static SkillBumpEventArgs Create()
//    {
//        SkillBumpEventArgs e = ReferencePool.Acquire<SkillBumpEventArgs>();
//        return e;
//    }

//    public override void Clear()
//    {
//    }
//}
