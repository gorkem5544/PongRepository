using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes
{
    public class TimerText : MonoBehaviour
    {
        TextMeshProUGUI _timerText;
        float _currentTime = 0;
        private void Awake()
        {
            _timerText = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            TimerMethod();
        }

        public void TimerMethod()
        {
            if (UiManager.Instance.CanTimeWork)
            {
                _currentTime += Time.deltaTime;
                float minutes = Mathf.FloorToInt(_currentTime / 60);
                float seconds = Mathf.FloorToInt(_currentTime % 60);
                _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }

        }

    }

}