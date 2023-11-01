using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.EnemyControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.PlayerControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class LevelManager : SingletonDontDestroyMono<LevelManager>
    {
        public void LoadLevel(string levelName)
        {
            StartCoroutine(LoadLevelAsync(levelName));
        }
        IEnumerator LoadLevelAsync(string levelName)
        {
            yield return SceneManager.LoadSceneAsync(levelName);
            ScoreManager.Instance.ClearScore();
            GameManager.Instance.IsGameStarting = false;
            SpawnerManager.Instance.SpawnAction();
        }
        public void ExitGame()
        {
            Application.Quit();
        }

    }

}