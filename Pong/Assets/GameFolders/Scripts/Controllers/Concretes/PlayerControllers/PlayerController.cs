using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Inputs.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Inputs.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Concretes;
using UnityEngine;


namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.PlayerControllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        private const string BallObjTag = "Ball";
        LaunchingBall _launchingBall;

        IMover _mover;
        public IMover Mover => _mover;

        [SerializeField] PlayerSO _playerSO;
        public IPlayerSO PlayerSO => _playerSO;

        IPlayerInput _playerInput;
        public IPlayerInput PlayerInput => _playerInput;

        public BallController BallController { get; set; }


        private bool _canLaunch, _isGameStarting;
        private void Awake()
        {
            BallController = SpawnerManager.Instance.NewBallController;
            //BallController = GameObject.FindWithTag(BallObjTag).GetComponent<BallController>();
            _launchingBall = new LaunchingBall(BallController);
            _playerInput = new PlayerInput();
            _mover = new MoveWithTranslate(this);
        }

        private void Update()
        {
            if (_playerInput.MouseClick && GameManager.Instance.GameState == GameManager.GameManagerStateEnum.GameStarting)
            {
                GameManager.Instance.GameState = GameManager.GameManagerStateEnum.LaunchBall;

            }
        }
        private void FixedUpdate()
        {
            if (GameManager.Instance.GameState == GameManager.GameManagerStateEnum.LaunchBall)
            {
                _launchingBall.LaunchBallAction();
                GameManager.Instance.GameState = GameManager.GameManagerStateEnum.Game;
            }
            _mover.MoveTick(_playerInput.VerticalInput, _playerSO.MoveSpeed);

        }
    }

}