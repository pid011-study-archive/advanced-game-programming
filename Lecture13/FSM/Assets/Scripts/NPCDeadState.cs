using UnityEngine;

public class NPCDeadState : NPCBaseState
{
    public override void Begin(NPCFSMMgr mgr)
    {
        Debug.Log("NPCDeadState Begin");
    }

    public override void Update(NPCFSMMgr mgr)
    {
        Debug.Log("NPCDeadState Update");
    }

    public override void End(NPCFSMMgr mgr)
    {
        Debug.Log("NPCDeadState End");
    }

    public override void OnCollisionEnter(NPCFSMMgr mgr)
    {
        Debug.Log("NPCDeadState OnCollisionEnter");
    }
}
