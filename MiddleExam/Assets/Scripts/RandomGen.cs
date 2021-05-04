using UnityEngine;

public class RandomGen : MonoBehaviour
{
    [SerializeField]
    private float radius = 5f;

    [SerializeField]
    private GameObject treePrefab;

    [SerializeField]
    private int count = 20;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(-radius, radius);
            float z = Random.Range(-radius, radius);

            Instantiate(treePrefab, new Vector3(x, 0, z), Quaternion.Euler(0, Random.Range(0f, 180f), 0));
        }
    }
}
