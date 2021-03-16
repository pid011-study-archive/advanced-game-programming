using System.Collections;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;

    private int _score;
    private bool _gameEnd;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void AddScore()
    {
        _score += 100;
        Debug.Log($"현재 스코어: {_score}");
    }

    private void Update()
    {
        if (!_gameEnd && _score == 1000)
        {
            Debug.Log("축하합니다.");
            StartCoroutine(QuitGame());
            _gameEnd = true;
        }
    }

    private IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(3);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
