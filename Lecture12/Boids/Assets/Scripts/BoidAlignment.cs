using System.Collections.Generic;

using UnityEngine;

public class BoidAlignment : BoidBehaviour
{
    public override Vector2 CalculateMove(Boid agent, List<Transform> context, FlockMgr flockMgr)
    {
        if (context.Count == 0) return agent.transform.up;

        Vector2 alignmentMove = Vector2.zero;
        List<Transform> filteredContext = context;

        foreach (var item in filteredContext)
        {
            alignmentMove += (Vector2)item.transform.up;
        }
        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
