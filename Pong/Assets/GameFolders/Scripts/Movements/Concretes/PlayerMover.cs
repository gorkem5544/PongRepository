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
        IPlayerController _playerController;
        float yBoundary;
        public PlayerMover(IPlayerController playerController)
        {
            _playerController = playerController;
        }

        public void FixedUpdate()
        {
            _playerController.transform.Translate(Vector2.up * _playerController.PlayerInput.VerticalInput * Time.deltaTime * _playerController.PlayerSO.MoveSpeed);
        }


        public void MoveUpdate()
        {
            if (_playerController.PlayerInput.VerticalInput == 0)
            {
                return;
            }
            yBoundary = Math.Clamp(_playerController.transform.position.y, -3.6f, 2.7f);
            _playerController.transform.position = new Vector3(_playerController.transform.position.x, yBoundary, 0);

        }
    }

}