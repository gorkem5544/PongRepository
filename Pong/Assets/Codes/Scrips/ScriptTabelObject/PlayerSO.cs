using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerSO
{
    float MoveSpeed { get; }
}
namespace Concretes.ScripTableObject
{
    [CreateAssetMenu(fileName = "Player Information", menuName = "Player Data/Create new Player Data")]
    public class PlayerSO : ScriptableObject, IPlayerSO
    {
        [SerializeField] float _moveSpeed;
        public float MoveSpeed => _moveSpeed;

    }

}