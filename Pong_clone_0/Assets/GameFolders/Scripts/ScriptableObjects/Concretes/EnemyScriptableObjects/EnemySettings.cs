using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Abstracts.OtherScriptableObjects;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.EnemyScriptableObjects
{

    [CreateAssetMenu(fileName = "EnemySettings", menuName = "Pong/EnemySettings", order = 0)]
    public class EnemySettings : ScriptableObject, IMoverSettings
    {
        [SerializeField] float _moveSpeed;
        public float MoveSpeed => _moveSpeed;
    }
}