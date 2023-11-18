using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Inputs.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Inputs.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.PlayerScriptableObjects;
using UnityEngine;


namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.PlayerControllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        LaunchingBall _launchingBall;
        IPlayerMover _mover;


        [SerializeField] PlayerSettings _playerSO;
        public PlayerSettings PlayerSO => _playerSO;

        IPlayerInput _playerInput;
        public IPlayerInput PlayerInput => _playerInput;

        private IBallController _ballController;
        public IBallController BallController => _ballController;
        private IScoreManager _playerScoreManager;
        public IScoreManager PlayerScoreManager => _playerScoreManager;

        const int PlayerInfo = 1;
        public int Info => PlayerInfo;

        private void Awake()
        {
            _playerScoreManager = new ScoreManager();
            _ballController = SpawnerManager.Instance.NewBallController;
            _launchingBall = new LaunchingBall(this);
            _playerInput = new PlayerInput();
            _mover = new PlayerMover(this);
        }

        private void Update()
        {
            if (_playerInput.MouseClick && GameManager.Instance.GameState == GameManager.GameManagerStateEnum.GameStarting)
            {
                GameManager.Instance.GameState = GameManager.GameManagerStateEnum.LaunchBall;
            }
            _mover.MoveUpdate();
        }
        private void FixedUpdate()
        {
            if (GameManager.Instance.GameState == GameManager.GameManagerStateEnum.LaunchBall)
            {
                _launchingBall.LaunchBallAction();
                GameManager.Instance.GameState = GameManager.GameManagerStateEnum.Game;
            }
            _mover.FixedUpdate();

        }
    }

}