using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class ScoreManager : IScoreManager
    {
        private int _score;
        public System.Action<int> OnScoreChanged { get; set; }
        public void AddScore(int value = 1)
        {
            _score += value;
            OnScoreChanged?.Invoke(_score);
        }
    }

}