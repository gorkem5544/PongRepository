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
        Rigidbody2D _rigidbody2D;
        public LaunchingBall(IBallController ballController)
        {
            _rigidbody2D = ballController.Rigidbody2D;
        }
        public void LaunchBallAction()
        {
            _rigidbody2D.AddForce(new Vector2(100, 25));
        }
    }

}