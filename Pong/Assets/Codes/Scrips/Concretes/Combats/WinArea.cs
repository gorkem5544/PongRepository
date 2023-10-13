using System.Collections;
using System.Collections.Generic;
using Abstracts.Combats;
using Concretes.Controllers;
using UnityEngine;

namespace Concretes.Combats
{
    public class WinArea : BaseArea
    {
        public event System.Action OnWin;
        private void OnTriggerEnter2D(Collider2D other)
        {
            BallController ballController = other.gameObject.GetComponent<BallController>();
            if (ballController != null)
            {
                OnWin?.Invoke();
                RestartAllObjectTransform();
                GameManager.Instance.IncreaseScore(1);
            }
        }
    }

}