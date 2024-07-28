using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Abstracts;
using Unity.Netcode;
using UnityEngine;

public class HostButton : BaseButton
{
    public override void HandleOnButtonClicked()
    {
        Debug.Log("Host button clicked");
        GameManager.Instance.SetHost(true);  // Host olarak ayarla
        LevelManager.Instance.LoadLevel("Game");  // Oyunu başlat
    }
}
