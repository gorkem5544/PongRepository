using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes
{
    public class LaunchingBall : ILaunchingBall
    {

        IBallController _ballController;
        public LaunchingBall(IPlayerController playerController)
        {
            _ballController = playerController.BallController;
        }
        public void LaunchBallAction()
        {
            _ballController.Rigidbody2D.AddForce(new Vector2(_ballController.BallSettings.MoveSpeed * 35, RandomYVelocity()));
        }
        private float RandomYVelocity()
        {
            float randomY = Random.Range(-25, 25);
            return randomY;
        }

    }

}