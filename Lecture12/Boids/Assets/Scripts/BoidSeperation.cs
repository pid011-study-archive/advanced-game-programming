using System.Collections.Generic;

using UnityEngine;

public class BoidSeperation : BoidBehaviour
{
    public override Vector2 CalculateMove(Boid agent, List<Transform> context, FlockMgr flockMgr)
    {
        if (context.Count == 0) return Vector2.zero;

        Vector2 avoidanceMove = Vector2.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = context;

        foreach (var item in filteredContext)
        {
            if ((item.position - agent.transform.position).sqrMagnitude < flockMgr.SquareAvoidRadius)
            {
                nAvoid++;
                avoidanceMove += (Vector2)(agent.transform.position - item.position);
            }
        }

        if (nAvoid > 0) avoidanceMove /= nAvoid;

        return avoidanceMove;
    }
}
