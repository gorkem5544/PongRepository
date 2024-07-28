using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.EnemyControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.PlayerControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class LevelManager : SingletonDontDestroyMono<LevelManager>
    {
        // IEnumerator LoadLevelAsync(string levelName)
        // {
        //     yield return SceneManager.LoadSceneAsync(levelName);
        //     SpawnerManager.Instance.SpawnAction();

        // }
        public static event System.Action<string> OnLevelLoaded;
        public static event System.Action<string> OnLevelUnloaded;
        public static event System.Action<string> OnLevelLoadingStarted;
        public void ExitGame()
        {
            Application.Quit();
        }

        public void LoadLevel(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            OnLevelLoadingStarted?.Invoke(sceneName);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);


            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            //GameManager.Instance.StartGame();
            OnLevelLoaded?.Invoke(sceneName);

        }

    }

}