using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Unity.Mathematics;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.EnemyControllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        BallController _ballController;
        [SerializeField] float _aiSpeed;
        private void Awake()
        {
            _ballController = SpawnerManager.Instance.NewBallController;
        }
        private void Update()
        {
            Vector3 newPosition = transform.position;
            float newPos = _ballController.transform.position.y;
            float Ai = math.lerp(newPosition.y, _ballController.transform.position.y, _aiSpeed * Time.deltaTime);
            newPosition.y = Ai;
            float yBoundary = Math.Clamp(newPosition.y, -3, 3);
            transform.position = new Vector2(transform.position.x, yBoundary);
        }
    }

}