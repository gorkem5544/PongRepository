using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using UnityEngine;

public class GameOverObj : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;
    private void Awake()
    {
        if (_gameOverPanel.activeSelf == true)
        {
            _gameOverPanel.SetActive(false);
        }

    }

    private void Start()
    {
        UIManager.Instance.OnLossEvent += HandleOnGameLoss;
    }
    private void OnDisable()
    {
        UIManager.Instance.OnLossEvent -= HandleOnGameLoss;

    }

    private void HandleOnGameLoss()
    {
        _gameOverPanel.SetActive(true);
    }
}
