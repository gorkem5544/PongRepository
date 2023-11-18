using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Abstracts.OtherScriptableObjects;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.OtherScriptableObjects
{
    [CreateAssetMenu(fileName = "BallSettings", menuName = "Pong/BallSettings", order = 0)]
    public class BallSettings : ScriptableObject, IMoverSettings
    {
        [SerializeField] float _moveSpeed;
        public float MoveSpeed => _moveSpeed;
    }
}