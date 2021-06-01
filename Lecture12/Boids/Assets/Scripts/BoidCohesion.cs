using System.Collections.Generic;

using UnityEngine;

public class BoidCohesion : BoidBehaviour
{
    public override Vector2 CalculateMove(Boid agent, List<Transform> context, FlockMgr flockMgr)
    {
        if (context.Count == 0) return Vector2.zero;

        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = context;
        foreach (var item in filteredContext)
        {
            cohesionMove += (Vector2)item.position;
        }

        cohesionMove /= context.Count;
        cohesionMove -= (Vector2)agent.transform.position;

        return cohesionMove;
    }
}
