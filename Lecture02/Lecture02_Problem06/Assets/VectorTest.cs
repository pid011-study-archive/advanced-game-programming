using UnityEngine;

public class VectorTest : MonoBehaviour
{
    private void Start()
    {
        Problem3();
        Problem5();
    }

    private void Problem3()
    {
        Vector3 a = new Vector3(2, 3, -3);
        Vector3 b = new Vector3(1, 2, 5);

        Vector3 sum = a + b;
        Debug.Log(sum);
    }

    private void Problem5()
    {
        Vector3 a = new Vector3(10, 10, 40);
        Vector3 b = new Vector3(20, 20, 30);

        Vector3 result = a + 2 * b;
        Debug.Log(result);
    }
}
