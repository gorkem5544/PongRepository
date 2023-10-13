using System.Collections;
using System.Collections.Generic;
using Abstracts.Controllers;
using UnityEngine;

namespace Concretes.Combats
{
    public class LaunchingBall
    {
        Rigidbody2D _rigidbody2D;
        public LaunchingBall(IBallController ballController)
        {
            _rigidbody2D = ballController.transform.GetComponent<Rigidbody2D>();
        }
        public void LaunchBall()
        {
            _rigidbody2D.AddForce(new Vector2(100, 25));

        }



    }

}