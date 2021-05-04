using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print($"OnCollisionEnter with {collision.gameObject.name}");
    }

    private void OnCollisionExit(Collision collision)
    {
        print($"OnCollisionExit with {collision.gameObject.name}");
    }

    private void OnCollisionStay(Collision collision)
    {
        print($"OnCollisionStay with {collision.gameObject.name}");
    }
}
