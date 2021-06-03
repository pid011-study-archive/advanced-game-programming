using UnityEngine;

public class NPCFSMMgr : MonoBehaviour
{
    private NPCBaseState _currentState;
    private NPCBaseState _prevState;

    public float traceRange = 100.0f;
    public float attackRange = 30.0f;
    public float npcHP = 100.0f;
    public Transform targetTransform;

    public NPCBaseState currentState => currentState;

    public readonly NPCIdleState idleState = new NPCIdleState();
    public readonly NPCTraceState traceState = new NPCTraceState();
    public readonly NPCAttackState attackState = new NPCAttackState();
    public readonly NPCDeadState deadState = new NPCDeadState();
    public readonly NPCEscapeState escapeState = new NPCEscapeState();

    private void Awake()
    {
        _currentState = idleState;
    }

    private void Start()
    {
        ChangeState(idleState);
    }

    private void Update()
    {
        _currentState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _currentState.OnCollisionEnter(this);
    }

    public void ChangeState(NPCBaseState state)
    {
        _currentState.End(this);
        _prevState = _currentState;
        _currentState = state;
        _currentState.Begin(this);
    }

    public float CalcTargetDistance()
    {
        return (targetTransform.position - transform.position).magnitude;
    }

    public bool CheckInTraceRange()
    {
        if (!IsAliveTarget()) return false;

        return CalcTargetDistance() < traceRange;
    }

    public bool CheckInAttackRange()
    {
        return CalcTargetDistance() < attackRange;
    }

    public bool IsAlive()
    {
        return npcHP > 0;
    }

    public bool IsAliveTarget()
    {
        return targetTransform;
    }

    public void MoveTarget()
    {
        var velo = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetTransform.position, ref velo, 0.1f);
    }
}
