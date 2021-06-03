public abstract class NPCBaseState
{
    public abstract void Begin(NPCFSMMgr mgr);
    public abstract void Update(NPCFSMMgr mgr);
    public abstract void End(NPCFSMMgr mgr);
    public abstract void OnCollisionEnter(NPCFSMMgr mgr);
}
