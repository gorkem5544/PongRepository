using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes
{
    public class ReturnMenuButton : BaseButton
    {
        private const string MenuName = "Menu";
        public override void HandleOnButtonClicked()
        {
            LevelManager.Instance.LoadLevel(MenuName);
            GameManager.Instance.GameState = GameManager.GameManagerStateEnum.ReturnMenu;
        }
    }

}