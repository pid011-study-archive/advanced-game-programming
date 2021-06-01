using System.Collections.Generic;

using UnityEngine;

public class FlockMgr : MonoBehaviour
{
    public Boid boidPrefab;
    private List<Boid> boids = new List<Boid>();
    public BoidBehaviour behaviourController;

    [Range(10, 500)] public int startingCount = 250;
    private const float AgentDensity = 0.08f;

    [Range(1f, 100f)] public float driveFactor = 10f;
    [Range(1f, 100f)] public float maxSpeed = 5f;
    [Range(1f, 10f)] public float neighborRadius = 1.5f;
    [Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;

    private float squareMaxSpeed;
    private float squareNeighborRadius;
    private float squareAvoidanceRadius;
    public float SquareAvoidRadius => squareAvoidanceRadius;

    private void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareAvoidanceRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            Boid newAgent = Instantiate(
                boidPrefab,
                Random.insideUnitCircle * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform);

            newAgent.name = "Agent" + i;
            newAgent.Initialize(this);
            boids.Add(newAgent);
        }
    }

    private void Update()
    {
        foreach (var boid in boids)
        {
            List<Transform> context = GetNearbyObjects(boid);

            Vector2 move = behaviourController.CalculateMove(boid, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            boid.Move(move);
        }
    }

    private List<Transform> GetNearbyObjects(Boid boid)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(boid.transform.position, neighborRadius);
        foreach (Collider2D collider in contextColliders)
        {
            if (collider != boid.AgentCollider)
            {
                context.Add(collider.transform);
            }
        }

        return context;
    }
}
