using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts.OtherControllers
{
    public abstract class BaseAreaController : MonoBehaviour
    {
        /// <summary>
        /// Kod Tekrarını önlemek için yazıldı
        /// </summary>
        protected virtual void BaseBallTriggerEnterMethod(Collider2D collider2D, GameManager.GameManagerStateEnum gameManagerStateEnum)
        {
            IBallController ballController = collider2D.gameObject.GetComponent<IBallController>();
            if (ballController != null)
            {
                GameManager.Instance.GameState = gameManagerStateEnum;
            }
        }
    }

}