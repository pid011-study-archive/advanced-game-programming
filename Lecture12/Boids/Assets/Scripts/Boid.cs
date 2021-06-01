using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Boid : MonoBehaviour
{
    public FlockMgr AgentFlock => agentFlock;
    public Collider2D AgentCollider => agentCollider;

    private FlockMgr agentFlock;
    private Collider2D agentCollider;

    private void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void Initialize(FlockMgr flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
