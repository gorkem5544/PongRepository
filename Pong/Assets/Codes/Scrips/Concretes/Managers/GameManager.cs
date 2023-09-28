using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score = 0;
    public System.Action<int> OnScoreChanged;
    public bool GameStarted = false;

    [SerializeField] PlayerController _playerController;
    Vector2 _playerStartingPosition, _ballStartingPosition, _enemyStartingPosition;
    [SerializeField] BallController _ballController;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        _playerStartingPosition = _playerController.transform.position;
        _ballStartingPosition = _ballController.transform.position;
    }



    public void RestartAllObjects()
    {
        _playerController.transform.position = _playerStartingPosition;
        _ballController.transform.position = _ballStartingPosition;

        _ballController.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameStarted = false;
    }
    public void IncreaseScore(int amount)
    {
        Score += amount;

        OnScoreChanged?.Invoke(Score);

    }

}
