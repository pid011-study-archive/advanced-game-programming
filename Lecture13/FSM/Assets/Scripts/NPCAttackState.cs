using UnityEngine;

public class NPCAttackState : NPCBaseState
{
    public override void Begin(NPCFSMMgr mgr)
    {
        Debug.Log("NPCAttackState Begin");
    }

    public override void End(NPCFSMMgr mgr)
    {
        Debug.Log("NPCAttackState End");
    }

    public override void OnCollisionEnter(NPCFSMMgr mgr)
    {
        Debug.Log("NPCAttackState OnCollisionEnter");
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
        if (!mgr.CheckInAttackRange())
        {
            mgr.ChangeState(mgr.traceState);
            return;
        }

        mgr.ChangeState(mgr.escapeState);
    }
}
