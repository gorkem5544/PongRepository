using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class UIManager : SingletonDontDestroyMono<UIManager>
    {
        public event System.Action OnLossEvent;

        public void OpenGameOverPanel()
        {
            OnLossEvent?.Invoke();
        }


    }

}