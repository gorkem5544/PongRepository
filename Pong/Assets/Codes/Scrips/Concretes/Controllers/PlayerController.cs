using System;
using System.Collections;
using System.Collections.Generic;
using Abstracts.Controllers;
using Abstracts.Movements;
using Concretes.Combats;
using Concretes.Inputs;
using Concretes.Movements;
using Concretes.ScripTableObject;
using UnityEngine;


namespace Concretes.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {


        IMover _mover;
        [SerializeField] PlayerSO _playerSO;
        IPlayerInput _playerInput;
        [SerializeField] BallController _ballController;
        LaunchingBall _launchingBall;

        private void Awake()
        {
            _launchingBall = new LaunchingBall(_ballController);
            _playerInput = new PlayerInput();
            _mover = new MoveWithTranslate(this);

        }


        private void Update()
        {

            if (_playerInput.MouseClick && !GameManager.Instance.GameStarting)
            {
                GameManager.Instance.GameStarting = true;
                _launchingBall.LaunchBall();
            }
        }
        private void FixedUpdate()
        {
            _mover.MoveTick(_playerInput.VerticalInput, _playerSO.MoveSpeed);
        }
    }

}