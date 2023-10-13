using System.Collections;
using System.Collections.Generic;
using Abstracts.Uis;
using UnityEngine;

namespace Concretes.Uis
{
    public class GameStartButton : BaseButton
    {
        public override void HandleOnButtonClicked()
        {

            GameManager.Instance.LoadLevel("Game");
        }

    }

}