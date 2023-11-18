using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers
{
    public abstract class ParticleController : LifeCircleController
    {
        protected override void DestroyObject()
        {
            KillObject();
        }
        protected abstract void KillObject();
    }

}