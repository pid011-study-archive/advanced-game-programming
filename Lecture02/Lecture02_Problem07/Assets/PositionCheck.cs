using UnityEngine;

public class PositionCheck : MonoBehaviour
{
    private GameObject _playerObject;

    private void Awake()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(_playerObject);
    }

    private void Update()
    {
        if (transform.position == _playerObject.transform.position)
        {
            GameManager.Instance.AddScore();
            Destroy(gameObject);
        }
    }
}
