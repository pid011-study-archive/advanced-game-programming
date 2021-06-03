using UnityEngine;

public class NPCEscapeState : NPCBaseState
{
    private Vector3 _startPos;
    private Vector3 _endPos;
    private Vector3 _direction;
    private float _escapeDistance;

    public override void Begin(NPCFSMMgr mgr)
    {
        _startPos = mgr.transform.position;
        _direction = (_startPos - mgr.targetTransform.position).normalized;
        _escapeDistance = mgr.traceRange * 0.5f;
        _endPos = _direction * _escapeDistance;
        _endPos.y = _startPos.y;
    }

    public override void Update(NPCFSMMgr mgr)
    {
        var pos = mgr.transform.position;
        var move = Vector3.Lerp(pos, _endPos, Time.deltaTime * 2f);
        mgr.transform.position = move;

        if (Vector3.Distance(pos, move) < 0.001f)
        {
            mgr.ChangeState(mgr.idleState);
        }
    }

    public override void End(NPCFSMMgr mgr)
    {
    }

    public override void OnCollisionEnter(NPCFSMMgr mgr)
    {
    }
}