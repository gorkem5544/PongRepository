using System.Collections;
using System.Collections.Generic;
using Abstracts.Uis;
using UnityEngine;

namespace Concretes.Uis
{
    public class NoButton : BaseButton
    {
        public override void HandleOnButtonClicked()
        {
            Application.Quit();
        }
    }

}