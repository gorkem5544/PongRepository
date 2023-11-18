using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Statics;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class ParticleManager : SingletonDontDestroyMono<ParticleManager>
    {
        [SerializeField] BoxCollider2D _playerGoalRandomSpawnCollider;


        public void BallHitParticleMethod(Vector2 spawnPosition)
        {
            ParticleController newBallHitParticle = BallHitPool.Instance.Get();
            newBallHitParticle.gameObject.SetActive(true);
            newBallHitParticle.transform.position = spawnPosition;
        }

        public void EntityGoalParticleStart()
        {
            for (int i = 0; i < 4; i++)
            {
                ParticleController newParticleController = EntityGoalParticlePool.Instance.Get();
                newParticleController.gameObject.SetActive(true);
                newParticleController.transform.position = Utils.GetRandomPoint(_playerGoalRandomSpawnCollider);
            }
        }


    }

}