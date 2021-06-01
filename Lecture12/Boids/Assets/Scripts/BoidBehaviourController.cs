using System.Collections.Generic;

using UnityEngine;

public class BoidBehaviourController : BoidBehaviour
{
    public BoidBehaviour[] behaviors;
    public float[] weights;

    public override Vector2 CalculateMove(Boid agent, List<Transform> context, FlockMgr flockMgr)
    {
        if (weights.Length != behaviors.Length)
        {
            Debug.LogError("Data mismatch in " + name, this);
            return Vector2.zero;
        }

        Vector2 move = Vector2.zero;

        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 partialMove = behaviors[i].CalculateMove(agent, context, flockMgr) * weights[i];

            if (partialMove != Vector2.zero)
            {
                if (partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }
                move += partialMove;
            }
        }

        return move;
    }
}
