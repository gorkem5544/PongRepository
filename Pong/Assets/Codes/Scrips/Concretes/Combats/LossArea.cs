using System.Collections;
using System.Collections.Generic;
using Abstracts.Combats;
using Concretes.Controllers;
using UnityEngine;

namespace Concretes.Combats
{
    public class LossArea : BaseArea
    {
        public event System.Action OnLoss;
        private void OnTriggerEnter2D(Collider2D other)
        {
            BallController ballController = other.gameObject.GetComponent<BallController>();
            if (ballController != null)
            {
                RestartAllObjectTransform();
                OnLoss?.Invoke();
            }
        }
    }

}