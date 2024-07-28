using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Unity.Netcode;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{

    public GameObject playerPrefab;
    public Vector3 hostStartPosition = new Vector3(-7f, 0f, 0f);
    public Vector3 clientStartPosition = new Vector3(7f, 0f, 0f);
    public Quaternion hostStartRotation = new Quaternion(0, 0, 0, 0);
    public Quaternion clientStartRotation = new Quaternion(0, 0, 180, 0);

    private void Start()
    {
        if (NetworkManager.Singleton == null)
        {
            Debug.LogError("NetworkManager Singleton is not initialized.");
            return;
        }

        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;

        if (GameManager.Instance.IsHost)
        {
            Debug.Log("Starting as Host");
            if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
            {
                NetworkManager.Singleton.StartHost();
                SpawnPlayer(NetworkManager.Singleton.LocalClientId, hostStartPosition, hostStartRotation);
            }
        }
        else
        {
            Debug.Log("Starting as Client");
            if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
            {
                NetworkManager.Singleton.StartClient();
            }
        }
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnectedCallback;
        }
    }

    private void OnClientConnectedCallback(ulong clientId)
    {
        Debug.Log($"Client connected: {clientId}");
        if (NetworkManager.Singleton.IsServer && clientId != NetworkManager.Singleton.LocalClientId)
        {
            SpawnPlayer(clientId, clientStartPosition, clientStartRotation);
        }
    }

    private void SpawnPlayer(ulong clientId, Vector3 position, Quaternion rotation)
    {
        if (playerPrefab == null)
        {
            Debug.LogError("Player Prefab is not assigned.");
            return;
        }

        GameObject player = Instantiate(playerPrefab, position, rotation);
        NetworkObject networkObject = player.GetComponent<NetworkObject>();

        if (networkObject != null)
        {
            networkObject.SpawnAsPlayerObject(clientId);
            Debug.Log($"Player spawned for client {clientId} at position {position} with rotation {rotation}");
        }
        else
        {
            Debug.LogError("Player prefab does not have a NetworkObject component.");
        }
    }
}


