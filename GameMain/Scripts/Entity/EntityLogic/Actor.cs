using GameFramework;
using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public abstract class Actor : Entity, IComparable
    {
        [SerializeField]
        private ActorData m_ActorData = null;
        [SerializeField]
        private Animator m_Animator = null;
        [SerializeField]
        protected List<int> m_ActorSkillIdList = null;
        [SerializeField]
        protected int m_CurrentSelectedSkillIndex = -1;

        AnimationClip clip;

        AnimationEvent animEvent;

        public bool canMove;
        public ActorData ActorData
        {
            get
            {
                return m_ActorData;
            }
        }
        public bool IsDead
        {
            get
            {
                return m_ActorData.HP <= 0;
            }
        }

        public void ApplyDamage(Actor attacker, int damage, E_DamageType damageType)
        {
            int netDamage = 0;
            switch (damageType)
            {
                case E_DamageType.Physics:
                    netDamage = damage - (int)(damage * m_ActorData.PhysicsDfsRatio);
                    break;
                case E_DamageType.Spell:
                    netDamage = damage - (int)(damage * m_ActorData.SpellDfsRatio);
                    break;
            }

            m_ActorData.HP -= netDamage;
            if (m_ActorData.HP <= 0)
            {
                OnDead(attacker);
            }
        }


        protected override void OnInit(object userData)
        {
            m_ActorData = userData as ActorData;

            m_Animator = GetComponent<Animator>();
            m_ActorSkillIdList = new List<int>(8);

            if (m_ActorData == null)
            {
                Log.Error("Actor data is invalid.");
            }
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_ActorData = userData as ActorData;
            if (m_ActorData == null)
            {
                Log.Error("Actor data is invalid");
            }

            Name = Utility.Text.Format("Actor ({0})", Id);


        }

        protected virtual void OnDead(Entity attacker)
        {
        }


        //actor之间的大小比较按各自数据的先攻值来比较
        public int CompareTo(object obj)
        {
            int result;
            try
            {
                if (this.m_ActorData.Priority >= (obj as Actor).m_ActorData.Priority)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("排序异常");
            }
        }


        /// <summary>
        /// 每回合开始恢复SP
        /// </summary>
        public void RestoreSP()
        {
            m_ActorData.SP += (int)(0.6 * m_ActorData.MaxSP);
            GameEntry.Event.Fire(this, UpdateActorFormInfoArgs.Create());
        }

        /// <summary>
        /// 消耗SP
        /// </summary>
        /// <param name="SP"></param>
        public bool ConsumeSP(int SP)
        {
            if (m_ActorData.SP < SP)
            {
                return false;
            }

            m_ActorData.SP -= SP;
            GameEntry.Event.Fire(this, UpdateActorFormInfoArgs.Create());
            return true;
        }

        /// <summary>
        /// Actor执行技能时的操作
        /// </summary>
        public bool DoSkill(SkillConfig skillConfig)
        {
            //消耗SP
            if (ConsumeSP(skillConfig.SPConsume))
            {
                //执行动画
                DoAnimation(skillConfig.AnimationName, skillConfig.AnimationEventTiming);
                canMove = false;
                return true;
            }

            return false;
        }

        protected void DoAnimation(string AnimationName, float AnimationEventTiming)
        {
            if (m_Animator != null)
            {
                m_Animator.Play(AnimationName);
                StartCoroutine(WaitForAnimationPlay(AnimationEventTiming));
            }
        }

        IEnumerator WaitForAnimationPlay(float AnimationEventTiming)
        {
            yield return null;
            animEvent = new AnimationEvent();
            animEvent.functionName = "SkillFire";
            animEvent.time = AnimationEventTiming;
            clip = m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            clip.AddEvent(animEvent);
        }

        private void SkillFire()
        {
            GameEntry.Event.Fire(this, SkillFireEventArgs.Create());
        }
    }

    public class SkillFireEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(SkillFireEventArgs).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public static SkillFireEventArgs Create()
        {
            SkillFireEventArgs e = ReferencePool.Acquire<SkillFireEventArgs>();
            return e;
        }

        public override void Clear()
        {
        }
    }
}
