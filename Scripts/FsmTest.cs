using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class FsmTest : MonoBehaviour
{
    private IFsm<Actor> fsm = null;
    private void Start()
    {
        Actor actor = new Actor();
        fsm = RPGGame.GameEntry.Fsm.GetFsm<Actor>("ActorFsm");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            
        }
    }
}



public class IdleState : FsmState<Actor>,IReference
{
    IdleState i;

    protected override void OnInit(IFsm<Actor> fsm)
    {
        base.OnInit(fsm);
        i = ReferencePool.Acquire<IdleState>();
        
    }

    protected override void OnDestroy(IFsm<Actor> fsm)
    {
        Clear();
        ReferencePool.Release(i);
        base.OnDestroy(fsm);
    }

    protected override void OnEnter(IFsm<Actor> fsm)
    {
        base.OnEnter(fsm);
        GameFrameworkLog.Debug("==========进入Idle=========");
        //ChangeState<MoveState>(fsm);
    }

    protected override void OnLeave(IFsm<Actor> fsm, bool isShutdown)
    {
        GameFrameworkLog.Debug("==========离开Idle=========");
        base.OnLeave(fsm, isShutdown);
    }

    protected override void OnUpdate(IFsm<Actor> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
    }

    public void Clear()
    {
        throw new System.NotImplementedException();
    }
}
public class MoveState : FsmState<Actor>,IReference
{
    protected override void OnInit(IFsm<Actor> fsm)
    {
        base.OnInit(fsm);
    }

    protected override void OnDestroy(IFsm<Actor> fsm)
    {
        base.OnDestroy(fsm);
    }

    protected override void OnEnter(IFsm<Actor> fsm)
    {
        base.OnEnter(fsm);
        GameFrameworkLog.Debug("==========进入Move=========");
        //ChangeState<IdleState>(fsm);
    }

    protected override void OnLeave(IFsm<Actor> fsm, bool isShutdown)
    {
        base.OnLeave(fsm, isShutdown);
        GameFrameworkLog.Debug("==========离开Move=========");
    }

    protected override void OnUpdate(IFsm<Actor> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
    }

    public void Clear()
    {
        throw new System.NotImplementedException();
    }
}

public class Actor
{
    private IFsm<Actor> fsm = null;
    public Actor()
    {
        FsmComponent fsmComponent = RPGGame.GameEntry.Fsm;
        fsm = fsmComponent.CreateFsm("ActorFsm", this, new IdleState(), new MoveState());
        fsm.Start<IdleState>();
    }
}