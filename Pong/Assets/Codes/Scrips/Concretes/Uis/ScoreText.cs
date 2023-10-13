using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Concretes.Uis
{
    public class ScoreText : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI _scoreText;
        private void Start()
        {
            GameManager.Instance.OnScoreChanged += HandleOnScoreChanged;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleOnScoreChanged;

        }

        private void HandleOnScoreChanged(int obj)
        {
            _scoreText.text = obj.ToString();
        }
    }

}