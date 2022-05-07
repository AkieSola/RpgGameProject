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
        protected List<Skill> SkillList = new List<Skill>() { null, null, null, null, null, null, null, null };

        public const int MaxSkillCount = 8;
        [SerializeField]
        protected Skill SelectedSkill = null;
        [SerializeField]
        private BuffContainer m_BuffContainer = null;

        AnimationClip clip;

        AnimationEvent animEvent;

        public bool canMove;

        public Material Transparent;
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

        public BuffContainer BuffContainer { get => m_BuffContainer; private set { m_BuffContainer = value; } }

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
                case E_DamageType.Pure:
                    netDamage = damage;
                    break;
            }

            m_ActorData.HP -= netDamage;
            DamageData damageData = new DamageData(netDamage, transform.position, damageType);
            GameEntry.UI.OpenUIForm(UIFormId.DamageTextForm, damageData);
            GameEntry.Event.Fire(this, UpdateActorFormInfoArgs.Create());

            if (m_ActorData.HP <= 0)
            {
                OnDead(attacker);
            }
        }


        protected override void OnInit(object userData)
        {
            m_ActorData = userData as ActorData;

            m_Animator = GetComponent<Animator>();

            m_BuffContainer = new BuffContainer(this);

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

            GameEntry.Event.Subscribe(ActorRoundStartEventArgs.EventId, WhenActorRoundStart);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            if (gameObject.GetComponent<MeshRenderer>().materials[1] != Transparent)
            {
                gameObject.GetComponent<MeshRenderer>().materials[1] = Transparent;
            }
        }

        private void WhenActorRoundStart(object sender, GameEventArgs e)
        {
            ActorRoundStartEventArgs ae = e as ActorRoundStartEventArgs;
            if (ae != null && ae.actor == this)
            {
                BuffContainer.BuffContainerEffect();
                foreach(var skill in SkillList)
                {
                    if(skill != null)
                    {
                        skill.Config.UpdateRestCoolDown();
                    }
                }
                if (this is Player)
                {
                    GameEntry.Event.Fire(this, UpdateSkillInfoEventArges.Create(SkillList));
                }
            }
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

        public void EndDoSkill()
        {
            GameEntry.Event.Fire(this, UpdateSkillInfoEventArges.Create(SkillList));
            SelectedSkill = null;
        }

        /// <summary>
        /// 动画播放时设置动画事件
        /// </summary>
        /// <param name="AnimationEventTiming">事件延迟时间</param>
        /// <returns></returns>
        IEnumerator WaitForAnimationPlay(float AnimationEventTiming)
        {
            yield return null;
            /// 设置动画事件
            animEvent = new AnimationEvent();
            animEvent.functionName = "SkillFire";
            animEvent.time = AnimationEventTiming;
            clip = m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            clip.AddEvent(animEvent);
        }

        private void SkillFire()
        {
            GameEntry.Event.Fire(this, SkillFireEventArgs.Create(SelectedSkill));
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

        public Skill skill;

        public static SkillFireEventArgs Create(Skill skill)
        {
            SkillFireEventArgs e = ReferencePool.Acquire<SkillFireEventArgs>();
            e.skill = skill;
            return e;
        }

        public override void Clear()
        {
            skill = null;
        }
    }
}
