using System.Collections;

using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _boxPrefab = null;

    private Coroutine _spawnCoroutine;

    public void StopSpawn()
    {
        if (_spawnCoroutine == null) return;

        StopCoroutine(_spawnCoroutine);
        _spawnCoroutine = null;
    }

    private void Awake()
    {
        Debug.Assert(_boxPrefab);
    }

    private void OnEnable()
    {
        _spawnCoroutine = StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopSpawn();
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            int x = Random.Range(-5, 6);
            int z = Random.Range(-5, 6);
            Vector3 pos = new Vector3(x, 5, z);
            var cube = Instantiate(_boxPrefab, pos, Quaternion.identity, transform);

            yield return new WaitForSeconds(5);
        }
    }
}
