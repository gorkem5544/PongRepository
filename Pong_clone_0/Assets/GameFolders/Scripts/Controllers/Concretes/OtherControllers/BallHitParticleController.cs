using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers
{
    public class BallHitParticleController : ParticleController
    {
        protected override void KillObject()
        {
            _currentLifeTime = 0;
            BallHitPool.Instance.SetPool(this);
        }
    }

}