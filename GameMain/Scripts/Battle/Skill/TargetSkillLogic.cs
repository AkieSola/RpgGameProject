using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public abstract class TargetSkillLogic : ISkillLogic
    {
        /// <summary>
        /// 初始化时，主要进行一些事件的订阅
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public abstract void OnInit(SkillConfig skillConfig, Actor Target);
        /// <summary>
        /// 刚开始释放技能时
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public abstract void OnLaunch(SkillConfig skillConfig, Actor Target);
        /// <summary>
        /// 释放出技能的时点
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public abstract void OnFire(SkillConfig skillConfig, Actor Target);
        /// <summary>
        /// 技能对象碰撞到目标单位时
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public abstract void OnBump(SkillConfig skillConfig, Actor Target);
        /// <summary>
        /// 技能释放结束
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public abstract void OnEnd(SkillConfig skillConfig, Actor Target);
        public void Launch(SkillConfig skillConfig, Actor Target, Vector3 poa)
        {
            OnLaunch(skillConfig, Target);
        }

        public void Clear(SkillConfig skillConfig, Actor Target, Vector3 poa)
        {
            throw new System.NotImplementedException();
        }
    }
}
