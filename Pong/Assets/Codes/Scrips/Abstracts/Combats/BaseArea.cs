using Concretes.Controllers;
using UnityEngine;

namespace Abstracts.Combats
{
    public abstract class BaseArea : MonoBehaviour
    {
        [SerializeField] PlayerController _playerController;
        [SerializeField] EnemyController _enemyController;
        [SerializeField] BallController _ballController;

        Rigidbody2D _ballBody2D;

        public virtual void Awake()
        {
            _ballBody2D = _ballController.GetComponent<Rigidbody2D>();
        }
        public void RestartAllObjectTransform()
        {
            _playerController.transform.position = new Vector2(-7, 0);
            _enemyController.transform.position = new Vector2(7, 0);
            _ballController.transform.position = Vector2.zero;
            _ballBody2D.velocity = Vector2.zero;
        }
    }
}