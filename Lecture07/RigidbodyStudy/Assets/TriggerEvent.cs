using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        print($"OnTriggerEnter with {other.gameObject.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        print($"OnTriggerExit with {other.gameObject.name}");
    }

    private void OnTriggerStay(Collider other)
    {
        print($"OnTriggerStay with {other.gameObject.name}");
    }
}
