using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonDontDestroyMono<LevelManager>
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] BallController _ballController;
    [SerializeField] EnemyController _enemyController;



    Vector2 _playerStartingPosition, _ballStartingPosition, _enemyStartingPosition;

    Rigidbody2D _ballRigidbody2D;

    protected override void Awake()
    {
        base.Awake();
        _ballRigidbody2D = _ballController.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _playerStartingPosition = new Vector2(-7, 0);
        _ballStartingPosition = Vector2.zero;
        _enemyStartingPosition = new Vector2(7, 0);


    }

    public void LoadLevel(string levelName)
    {
        ScoreManager.Instance.ClearScore();
        RestartAllObjectsTransform();
        StartCoroutine(LoadLevelAsync(levelName));
    }
    IEnumerator LoadLevelAsync(string levelName)
    {
        yield return SceneManager.LoadSceneAsync(levelName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }


    public void RestartAllObjectsTransform()
    {
        _playerController.transform.position = _playerStartingPosition;
        _ballController.transform.position = _ballStartingPosition;
        _enemyController.transform.position = _enemyStartingPosition;

        _ballRigidbody2D.velocity = Vector2.zero;

    }

}
