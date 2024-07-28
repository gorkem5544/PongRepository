using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.PlayerUis
{
    public class PlayerScoreText : MonoBehaviour
    {
        TextMeshProUGUI _playerScoreText;

        private void Awake()
        {
            _playerScoreText = GetComponent<TextMeshProUGUI>();
        }
        void Start()
        {
            SpawnerManager.Instance.NewPlayerController.PlayerScoreManager.OnScoreChanged += HandleScoreChangedAction;
        }
        private void OnDisable()
        {
            SpawnerManager.Instance.NewPlayerController.PlayerScoreManager.OnScoreChanged -= HandleScoreChangedAction;
        }
        private void HandleScoreChangedAction(int obj)
        {
            _playerScoreText.text = obj.ToString();
        }
    }

}