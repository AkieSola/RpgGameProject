using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public abstract class TargetSkillLogic
    {
        public SkillConfig Config { get; set; }
        public Actor Target { get; set; }
        /// <summary>
        /// 初始化时，主要进行一些事件的订阅
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnInit() { }
        /// <summary>
        /// 刚开始释放技能时
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnLaunch() { }
        /// <summary>
        /// 释放出技能的时点
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnFire() { }
        /// <summary>
        /// 技能对象碰撞到目标单位时
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnBump() { }
        /// <summary>
        /// 技能释放结束
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnEnd() { }

        public void Clear(SkillConfig skillConfig, Actor Target, Vector3 poa)
        {
            throw new System.NotImplementedException();
        }

        public void Launch(SkillConfig skillConfig, Actor Target, Vector3 poa)
        {
            Config = skillConfig;
            this.Target = Target;
            OnLaunch();
        }
    }
}
