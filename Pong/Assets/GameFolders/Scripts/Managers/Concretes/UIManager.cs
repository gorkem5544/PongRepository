using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class UiManager : SingletonDontDestroyMono<UiManager>
    {
        public bool CanTimeWork { get; set; }
    }

}