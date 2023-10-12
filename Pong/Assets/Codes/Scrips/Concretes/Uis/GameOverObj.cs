using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverObj : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] LossArea _lossArea;
    private void Awake()
    {
        if (_gameOverPanel.activeSelf == true)
        {
            _gameOverPanel.SetActive(false);
        }

    }

    private void Start()
    {
        _lossArea.OnLoss += HandleOnGameLoss;
    }

    private void HandleOnGameLoss()
    {
        _gameOverPanel.SetActive(true);
    }
}
