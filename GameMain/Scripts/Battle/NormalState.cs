using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public class NormalState : FsmState<BattleMgr>
    {
        public List<Actor> battleActors;
        private float timer;

        private Player player;
        private IFsm<BattleMgr> fsm;

        protected override void OnInit(IFsm<BattleMgr> fsm)
        {
            base.OnInit(fsm);
            battleActors = new List<Actor>();
            player = fsm.Owner.player;
            this.fsm = fsm;
        }

        protected override void OnEnter(IFsm<BattleMgr> fsm)
        {
            base.OnEnter(fsm);
            GameEntry.Event.Subscribe(DialogEventArgs.EventId, DialogChangeToBattle);
            if (player != null)
            {
                player.canMove = true;
                player.inPlayerTurn = false;
            }
        }
        private void DialogChangeToBattle(object sender, GameEventArgs e)
        {
            Enemy actor = sender as Enemy;
            DialogEventArgs de = e as DialogEventArgs;

            if (de != null && de.dialogEventType == DialogEventType.ShiftToBattle)
            {
                if (actor != null)
                {
                    GameEntry.Event.Fire(fsm.Owner, NoticeGroupActorEnterBattleEventArgs.Create(actor.EnemyData.GroupId));
                }
                ChangeState<BattleState>(fsm);
            }


        }


        protected override void OnUpdate(IFsm<BattleMgr> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            //timer += Time.deltaTime;
            //if (timer >= 1f)
            //{
            //    timer = 0;
            //    if (fsm.Owner.player != null)
            //    {
            //        Collider[] colliders = Physics.OverlapSphere(fsm.Owner.player.transform.position, 10);
            //        battleActors.Clear();
            //        foreach (var collider in colliders)
            //        {
            //            Actor a;
            //            if (collider.TryGetComponent<Actor>(out a))
            //            {
            //                if (a != null)
            //                {
            //                    Log.Debug(fsm.CurrentState);
            //                    battleActors.Add(a);
            //                }
            //            }
            //        }

            //        if (battleActors.Count > 1)
            //        {
            //            fsm.Owner.battleActors = battleActors;
            //            ChangeState<BattleState>(fsm);
            //        }
            //    }
            //}
        }

        protected override void OnLeave(IFsm<BattleMgr> fsm, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(DialogEventArgs.EventId, DialogChangeToBattle);
            base.OnLeave(fsm, isShutdown);
        }
    }

    public class NoticeGroupActorEnterBattleEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(NoticeGroupActorEnterBattleEventArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public int GroupId;

        public static NoticeGroupActorEnterBattleEventArgs Create(int id)
        {
            NoticeGroupActorEnterBattleEventArgs e = ReferencePool.Acquire<NoticeGroupActorEnterBattleEventArgs>();
            e.GroupId = id;
            return e;
        }

        public override void Clear()
        {
            GroupId = 0;
        }
    }
}
