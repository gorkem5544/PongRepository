using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        BallController ballController = other.gameObject.GetComponent<BallController>();
        if (ballController != null)
        {
            GameManager.Instance.GameState = GameManager.EnumGameState.GameWin;

            ScoreManager.Instance.IncreaseScore(1);
        }
    }
}
