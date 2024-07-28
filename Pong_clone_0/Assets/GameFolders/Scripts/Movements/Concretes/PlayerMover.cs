using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Concretes
{

    public class PlayerMover : IPlayerMover
    {
        private IPlayerController _playerController;
        private float _yBoundary;
        public PlayerMover(IPlayerController playerController)
        {
            _playerController = playerController;
        }

        public void FixedUpdate()
        {
            float moveDirection = _playerController.PlayerInput.VerticalInput;
            Vector2 move = new Vector2(0, moveDirection);
            Vector2 adjustedMove = _playerController.transform.rotation * move;
            _playerController.transform.Translate(adjustedMove * _playerController.PlayerSO.MoveSpeed * Time.deltaTime);
        }
        public void MoveUpdate()
        {
            if (_playerController.PlayerInput.VerticalInput == 0)
            {
                return;
            }
            _yBoundary = Math.Clamp(_playerController.transform.position.y, -3.6f, 2.7f);
            _playerController.transform.position = new Vector3(_playerController.transform.position.x, _yBoundary, 0);

        }
    }

}