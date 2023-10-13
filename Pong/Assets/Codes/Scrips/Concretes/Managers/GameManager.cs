using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonDontDestroyMono<GameManager>
{
    public bool GameStarting { get; set; }

    public int Score = 0;
    public System.Action<int> OnScoreChanged;



    public void IncreaseScore(int amount)
    {
        Score += amount;
        GameStarting = false;
        OnScoreChanged?.Invoke(Score);
    }
    public void LoadLevel(string levelName)
    {
        GameStarting = false;
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
}
