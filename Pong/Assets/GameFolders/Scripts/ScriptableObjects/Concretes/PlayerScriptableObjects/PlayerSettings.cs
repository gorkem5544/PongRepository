using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Abstracts.OtherScriptableObjects;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.PlayerScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Information", menuName = "Player Data/Create new Player Data")]
    public class PlayerSettings : ScriptableObject, IMoverSettings
    {
        [SerializeField] float _moveSpeed;
        public float MoveSpeed => _moveSpeed;

    }

}