using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGGame
{
    public abstract class Skill : ISkillLogic
    {
        public SkillConfig Config { get; set; }
        public Actor Target { get; set; }
        public Vector3 TargetPosition { get; set; }
        public Vector3 ForwardDir { get; set; }

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
        public virtual void OnLaunch() 
        {
            Config.EnterCoolDown();
        }
        /// <summary>
        /// 释放出技能的时点
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnFire(object sender, GameEventArgs e) { }
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
        public virtual void OnEnd() {}

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
        
        public void Init(DRSkillConfig drSkillConfig, Actor Launcher)
        {
            Config = new SkillConfig(drSkillConfig, Launcher); 
            OnInit();
        }

        public void Launch(Actor Target, Vector3 Position, Vector3 ForwardDir)
        {
            this.Target = Target;
            this.TargetPosition = Position;
            this.ForwardDir = ForwardDir;
            OnLaunch();
        }
    }
}
