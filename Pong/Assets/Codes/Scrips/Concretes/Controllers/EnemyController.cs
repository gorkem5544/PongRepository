using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public interface IEnemyController : IEntityController
{

}
public class EnemyController : MonoBehaviour, IEnemyController
{
    [SerializeField] BallController _ball;
    [SerializeField] float _aiSpeed;

    private void Update()
    {
        Vector3 newPosition = transform.position;
        float newPos = _ball.transform.position.y;
        float Ai = math.lerp(newPosition.y, _ball.transform.position.y, _aiSpeed * Time.deltaTime);
        newPosition.y = Ai;
        float yBoundary = Math.Clamp(newPosition.y, -3, 3);
        transform.position = new Vector2(transform.position.x, yBoundary);
    }
}
