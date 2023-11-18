using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.EnemyScriptableObjects;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.EnemyControllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] EnemySettings _enemySettings;
        public EnemySettings EnemySettings => _enemySettings;

        private IScoreManager _enemyScoreManager;
        public IScoreManager EnemyScoreManager => _enemyScoreManager;

        IBallController _ballController;
        public IBallController BallController => _ballController;

        const int EnemyInfo = -1;
        public int Info => EnemyInfo;

        IEnemyMover _enemyMover;


        private void Awake()
        {
            _enemyScoreManager = new ScoreManager();
            _ballController = SpawnerManager.Instance.NewBallController;
            _enemyMover = new EnemyMove(this);
        }
        private void Update()
        {
            _enemyMover.MoveUpdate();
        }
        private void FixedUpdate()
        {
            _enemyMover.FixedUpdate();
        }
    }

}