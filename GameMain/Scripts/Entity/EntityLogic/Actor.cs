using GameFramework;
using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public abstract class Actor : Entity,IComparable
    {
        [SerializeField]
        private ActorData m_ActorData = null;

        public ActorData ActorData
        {
            get
            {
                return m_ActorData;
            }
        }

        public int ATK
        {
            get
            {
                return 100;
            }
        }

        public bool IsDead
        {
            get
            {
                return m_ActorData.HP <= 0;
            }
        }

        public void ApplyDamage(Entity attacker, int damageHP)
        {
            m_ActorData.HP -= damageHP;
            if (m_ActorData.HP <= 0)
            {
                OnDead(attacker);
            }
        }


        protected override void OnInit(object userData)
        {
            m_ActorData = userData as ActorData;

            m_ActorData.HP = 100;

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
            if(m_ActorData == null)
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

        //private void OnActorRoundStart(object sender, GameEventArgs e)
        //{
        //    RestoreSP();
        //}
    }
}
