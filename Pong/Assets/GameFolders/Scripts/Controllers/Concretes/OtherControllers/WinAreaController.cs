using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers
{
    public class WinAreaController : MonoBehaviour
    {
        public event System.Action OnWin;
        private void OnTriggerEnter2D(Collider2D other)
        {
            IBallController ballController = other.gameObject.GetComponent<IBallController>();
            if (ballController != null)
            {
                GameManager.Instance.GameState = GameManager.GameManagerStateEnum.GameWin;
                SpawnerManager.Instance.RestartAllObjectsTransform();
                ScoreManager.Instance.IncreaseScore(1);
                Debug.Log("aaa");
                OnWin?.Invoke();
            }
        }
    }

}