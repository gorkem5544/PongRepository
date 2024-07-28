using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using Unity.Mathematics;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Concretes
{
    public class EnemyMove : IEnemyMover
    {
        IEnemyController _enemyController;
        Vector3 _newPosition;
        float _ai;
        float _yBoundary;
        public EnemyMove(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void MoveUpdate()
        {
            _newPosition = _enemyController.transform.position;
            _ai = math.lerp(_newPosition.y, _enemyController.BallController.transform.position.y, _enemyController.EnemySettings.MoveSpeed * Time.deltaTime);
            _newPosition.y = _ai;
            _yBoundary = Math.Clamp(_newPosition.y, -3.6f, 2.7f);
        }
        public void FixedUpdate()
        {
            _enemyController.transform.position = new Vector2(_enemyController.transform.position.x, _yBoundary);
        }
    }

}