using System.Collections.Generic;

using UnityEngine;

public abstract class BoidBehaviour : MonoBehaviour
{
    public abstract Vector2 CalculateMove(Boid agent, List<Transform> context, FlockMgr flockMgr);
}
