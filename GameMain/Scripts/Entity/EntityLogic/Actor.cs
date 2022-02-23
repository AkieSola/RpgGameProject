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

        public bool IsDead
        {
            get
            {
                return m_ActorData.HP <= 0;
            }
        }

        public abstract ImpactData GetImpactData();

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
            if (m_ActorData == null)
            {
                Log.Error("Actor data is invalid.");
            }
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
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
    }
}
