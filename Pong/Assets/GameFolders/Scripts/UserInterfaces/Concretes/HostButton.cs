using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Abstracts;
using Unity.Netcode;
using UnityEngine;

public class HostButton : BaseButton
{
    public override void HandleOnButtonClicked()
    {
        NetworkManager.Singleton.StartHost();
    }
}
