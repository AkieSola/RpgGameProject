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
        /// ��ʼ��ʱ����Ҫ����һЩ�¼��Ķ���
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnInit() { }
        /// <summary>
        /// �տ�ʼ�ͷż���ʱ
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnLaunch() { }
        /// <summary>
        /// �ͷų����ܵ�ʱ��
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnFire() { }
        /// <summary>
        /// ���ܶ�����ײ��Ŀ�굥λʱ
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnBump() { }
        /// <summary>
        /// �����ͷŽ���
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