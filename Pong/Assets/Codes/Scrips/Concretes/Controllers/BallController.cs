using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine;


interface IBallController : IEntityController
{

}
public class BallController : MonoBehaviour, IBallController
{

    Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController playerController = other.collider.GetComponent<PlayerController>();
        EnemyController enemyController = other.collider.GetComponent<EnemyController>();


        if (playerController != null)
        {
            float directionVertical = (transform.position.y - playerController.transform.position.y) / other.collider.bounds.extents.y;
            _rigidbody2D.AddForce(new Vector2(directionVertical, directionVertical) * 100f);
        }
        if (enemyController != null)
        {
            float directionVertical = (transform.position.y - enemyController.transform.position.y) / other.collider.bounds.extents.y;
            _rigidbody2D.AddForce(new Vector2(-directionVertical, directionVertical) * 100f);
        }
    }
}
