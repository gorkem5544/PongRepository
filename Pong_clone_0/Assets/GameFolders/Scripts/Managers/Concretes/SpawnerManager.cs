using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.EnemyControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.PlayerControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using Unity.Netcode;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class SpawnerManager : SingletonDontDestroyMono<SpawnerManager>
    {
        [SerializeField] private BallController _ballController;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private EnemyController _enemyController;

        public IBallController NewBallController { get; set; }
        public IPlayerController NewPlayerController { get; set; }
        public IEnemyController NewEnemyController { get; set; }

        Vector2 _playerStartingPosition, _ballStartingPosition, _enemyStartingPosition;

        private void Start()
        {
            _playerStartingPosition = new Vector2(-7, 0);
            _ballStartingPosition = Vector2.zero;
            _enemyStartingPosition = new Vector2(7, 0);
        }

        public void SpawnAction()
        {
            NewBallController = Instantiate(_ballController, GetPosition(_ballStartingPosition), Quaternion.identity);
            Debug.Log("Player İs Created");
            //NewPlayerController = Instantiate(_playerController, GetPosition(_playerStartingPosition), Quaternion.identity);
            NewPlayerController.transform.GetComponent<NetworkObject>().Spawn();
            NewEnemyController = Instantiate(_enemyController, GetPosition(_enemyStartingPosition), Quaternion.identity);
        }

        public void RestartAllObjectsTransform()
        {
            NewBallController.Rigidbody2D.velocity = Vector2.zero;
            NewPlayerController.transform.position = GetPosition(_playerStartingPosition);
            NewBallController.transform.position = GetPosition(_ballStartingPosition);
            NewEnemyController.transform.position = GetPosition(_enemyStartingPosition);
        }
        public Vector2 GetPosition(Vector2 vector)
        {
            return new Vector2(vector.x, vector.y);
        }


    }

}