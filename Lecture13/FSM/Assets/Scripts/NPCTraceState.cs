using UnityEngine;

public class NPCTraceState : NPCBaseState
{
    public override void Begin(NPCFSMMgr mgr)
    {
        Debug.Log("NPCTraceState Begin");
    }

    public override void End(NPCFSMMgr mgr)
    {
        Debug.Log("NPCTraceState End");
    }

    public override void OnCollisionEnter(NPCFSMMgr mgr)
    {
        Debug.Log("NPCTraceState OnCollisionEnter");
    }

    public override void Update(NPCFSMMgr mgr)
    {
        if (!mgr.IsAlive())
        {
            mgr.ChangeState(mgr.deadState);
            return;
        }
        if (!mgr.IsAliveTarget())
        {
            mgr.ChangeState(mgr.idleState);
            return;
        }
        if (!mgr.CheckInTraceRange())
        {
            mgr.ChangeState(mgr.idleState);
            return;
        }
        if (mgr.CheckInAttackRange())
        {
            mgr.ChangeState(mgr.attackState);
            return;
        }
        mgr.MoveTarget();
    }
}
