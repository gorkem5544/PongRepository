using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.EnemyControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers
{
    public class BallController : MonoBehaviour, IBallController
    {

        public Rigidbody2D Rigidbody2D { get; set; }
        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            IPlayerController playerController = other.collider.GetComponent<IPlayerController>();
            IEnemyController enemyController = other.collider.GetComponent<IEnemyController>();

            Vector2 hitPosition = transform.position;
            ParticleManager.Instance.BallHitParticleMethod(hitPosition);
            if (playerController != null)
            {
                float directionVertical = (transform.position.y - playerController.transform.position.y) / other.collider.bounds.extents.y;
                Rigidbody2D.AddForce(new Vector2(directionVertical, directionVertical) * 100f);
            }
            if (enemyController != null)
            {
                float directionVertical = (transform.position.y - enemyController.transform.position.y) / other.collider.bounds.extents.y;
                Rigidbody2D.AddForce(new Vector2(-directionVertical, directionVertical) * 100f);
            }
        }
    }

}