using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossArea : MonoBehaviour
{
    public event System.Action OnLoss;
    private void OnTriggerEnter2D(Collider2D other)
    {
        BallController ballController = other.gameObject.GetComponent<BallController>();
        if (ballController != null)
        {
            GameManager.Instance.GameState=GameManager.EnumGameState.GameOver;
            OnLoss?.Invoke();
        }
    }
}
