using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using UnityEngine;

public class GameStartButton : BaseButton
{
    public override void HandleOnButtonClicked()
    {
        GameManager.Instance.GameState = GameManager.GameManagerStateEnum.GameStarting;
        LevelManager.Instance.LoadLevel("Game");
    }

}
