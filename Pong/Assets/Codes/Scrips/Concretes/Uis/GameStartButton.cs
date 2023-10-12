using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButton : BaseButton
{
    public override void HandleOnButtonClicked()
    {
        GameManager.Instance.GameState = GameManager.EnumGameState.Menu;
        LevelManager.Instance.LoadLevel("Game");
    }

}
