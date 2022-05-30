using GameFramework;
using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public class Player : Actor
    {
        [SerializeField]
        private PlayerData m_PlayerData = null;
        public bool inPlayerTurn;
        float walkTimer = 0;

        Material material;


        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            this.ActorData.Camp = CampType.Player;

            EventComponent eventComponent = GameEntry.Event;
            canMove = true;

            m_PlayerData = userData as PlayerData;
            if (m_PlayerData == null)
            {
                Log.Error("Player data is invalid.");
                return;
            }
            //读取角色技能数据id
            //通过id拼类
            m_PlayerData.SkillIdList = new List<int> { 1, 2, 3, 0, 0, 0, 0, 0 };    //Test

            m_PlayerData.ItemIdList = new List<int> { 1, 2, 3, 4, 1, 2 };

            foreach (int id in m_PlayerData.ItemIdList)
            {
                if (m_PlayerData.ItemDic.ContainsKey(id))
                {
                    m_PlayerData.ItemDic[id].num += 1;
                }
                else
                {
                    Item item = new Item(GameEntry.DataTable.GetDataTable<DRItem>().GetDataRow(id), this);
                    m_PlayerData.ItemDic.Add(id, item);
                }
            }

            for (int i = 0; i < MaxSkillCount; i++)
            {
                SkillList[i] = SkillFactor.CreateSkill(m_PlayerData.SkillIdList[i], this);
            }

            Name = Utility.Text.Format("Player ({0})", Id);

            eventComponent.Fire(this, PlayerShowEventArgs.Create());
            eventComponent.Fire(this, UpdateSkillInfoEventArges.Create(SkillList));
            eventComponent.Subscribe(SelectedSkillEventArgs.EventId, SelectSkill);
            eventComponent.Subscribe(ActorPropChangeEventArgs.EventId, UpdateProp);
        }

        private void UpdateProp(object sender, GameEventArgs e)
        {
            nav.speed = ActorData.Speed;
        }

        private void SelectSkill(object sender, GameEventArgs e)
        {
            if (e != null)
            {
                SelectedSkillEventArgs ea = e as SelectedSkillEventArgs;
                if (ea.skill.Config.RestCoolDown == 0)
                {
                    SelectedSkill = ea.skill;
                }
                else
                {

                }
            }
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if (inPlayerTurn && nav.velocity != Vector3.zero)
            {
                //移动SP消耗
                walkTimer += Time.deltaTime;
                if (walkTimer >= 1f)
                {
                    walkTimer = 0;
                    base.ConsumeSP(1);
                }
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetMouseButtonDown(1) && canMove && m_PlayerData.SP > 0)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    nav.SetDestination(hit.point);
                }
            }

            if (material != null)
            {
                material.SetFloat("_OutlineLenth", 0f);
            }

            if (Physics.Raycast(ray, out hit, 1000, 1 << LayerMask.NameToLayer("Actor")))
            {
                material = hit.collider.gameObject.GetComponent<MeshRenderer>().materials[0];
                if (material != null)
                {
                    material.SetFloat("_OutlineLenth", 0.05f);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    if (inPlayerTurn && SelectedSkill != null)
                    {
                        if (SelectedSkill.Config.DRSkillConfig.Type == 1)
                        {
                            Actor Target = hit.collider.gameObject.GetComponent<Actor>();
                            Vector3 Position = hit.point;
                            Position.y = this.transform.position.y;
                            Vector3 ForwordDir = (Position - this.transform.position).normalized;
                            this.transform.LookAt(new Vector3(ForwordDir.x, this.transform.position.y, ForwordDir.z));
                            SelectedSkill.Launch(Target, Position, ForwordDir);
                        }
                        if (SelectedSkill.Config.DRSkillConfig.Type == 2)
                        {
                            SelectedSkill.Launch(this, this.transform.position, this.transform.forward);
                        }
                    }
                }
            }
        }
    }

    public class ActorPropChangeEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(PlayerShowEventArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public static ActorPropChangeEventArgs Create()
        {
            ActorPropChangeEventArgs e = ReferencePool.Acquire<ActorPropChangeEventArgs>();
            return e;
        }

        public override void Clear()
        {
        }
    }
    public class PlayerShowEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(PlayerShowEventArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public static PlayerShowEventArgs Create()
        {
            PlayerShowEventArgs e = ReferencePool.Acquire<PlayerShowEventArgs>();
            return e;
        }

        public override void Clear()
        {
        }
    }
}
