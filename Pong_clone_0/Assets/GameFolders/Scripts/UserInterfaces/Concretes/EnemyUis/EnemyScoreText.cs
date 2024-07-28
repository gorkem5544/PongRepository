using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using TMPro;
using UnityEngine;

public class EnemyScoreText : MonoBehaviour
{
    TextMeshProUGUI _enemyScoreText;

    private void Awake()
    {
        _enemyScoreText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        SpawnerManager.Instance.NewEnemyController.EnemyScoreManager.OnScoreChanged += HandleScoreChangedAction;
    }
    private void OnDisable()
    {
        SpawnerManager.Instance.NewEnemyController.EnemyScoreManager.OnScoreChanged -= HandleScoreChangedAction;
    }
    private void HandleScoreChangedAction(int obj)
    {
        _enemyScoreText.text = obj.ToString();
    }

}
