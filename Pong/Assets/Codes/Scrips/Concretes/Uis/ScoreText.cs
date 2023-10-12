using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _scoreText;
    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += HandleOnScoreChanged;
    }
    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChanged -= HandleOnScoreChanged;

    }

    private void HandleOnScoreChanged(int obj)
    {
        _scoreText.text = obj.ToString();
    }
}
