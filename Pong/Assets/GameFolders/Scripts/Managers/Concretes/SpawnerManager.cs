using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.EnemyControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.PlayerControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class SpawnerManager : SingletonDontDestroyMono<SpawnerManager>
    {
        [SerializeField] private BallController _ballController;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private EnemyController _enemyController;

        public BallController NewBallController { get; set; }
        public PlayerController NewPlayerController { get; set; }
        public EnemyController NewEnemyController { get; set; }

        public void SpawnAction()
        {
            NewBallController = Instantiate(_ballController, GetPosition(GameManager.Instance.BallStartingPosition), Quaternion.identity) as BallController;
            NewPlayerController = Instantiate(_playerController, GetPosition(GameManager.Instance.PlayerStartingPosition), Quaternion.identity) as PlayerController;
            NewEnemyController = Instantiate(_enemyController, GetPosition(GameManager.Instance.EnemyStartingPosition), Quaternion.identity) as EnemyController;



            Debug.Log("Spawn Action");
        }
        public Vector2 GetPosition(Vector2 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public void RestartAllObjectsTransform()
        {
            GameManager.Instance.IsGameStarting = false;
            _ballController.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            _playerController.transform.position = new Vector3(GameManager.Instance.PlayerStartingPosition.x, GameManager.Instance.PlayerStartingPosition.y);
            _ballController.transform.position = new Vector3(GameManager.Instance.BallStartingPosition.x, GameManager.Instance.BallStartingPosition.y);
            _enemyController.transform.position = new Vector3(GameManager.Instance.EnemyStartingPosition.x, GameManager.Instance.EnemyStartingPosition.y);
        }
    }

}