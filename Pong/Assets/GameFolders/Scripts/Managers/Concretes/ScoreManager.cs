using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class ScoreManager : SingletonDontDestroyMono<ScoreManager>
    {
        public int Score = 0;
        public System.Action<int> OnScoreChanged;
        public void IncreaseScore(int amount)
        {
            Score += amount;
            OnScoreChanged?.Invoke(Score);
        }
        public void ClearScore()
        {
            Score = 0;
        }
    }

}