using UnityEngine;

public class NPCIdleState : NPCBaseState
{
    public override void Begin(NPCFSMMgr mgr)
    {
        Debug.Log("NPCIdleState Begin");
    }

    public override void Update(NPCFSMMgr mgr)
    {
        if (!mgr.IsAlive())
        {
            mgr.ChangeState(mgr.deadState);
        }
        if (mgr.CheckInTraceRange())
        {
            mgr.ChangeState(mgr.traceState);
            return;
        }

    }

    public override void End(NPCFSMMgr mgr)
    {
        Debug.Log("NPCIdleState End");
    }

    public override void OnCollisionEnter(NPCFSMMgr mgr)
    {
        Debug.Log("NPCIdleState OnCollsionEnter");
    }
}
