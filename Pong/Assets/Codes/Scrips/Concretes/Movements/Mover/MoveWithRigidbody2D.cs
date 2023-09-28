using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithRigidbody2D : IMover
{
    Rigidbody2D _rigidbody2D;
    public MoveWithRigidbody2D(IPlayerController playerController)
    {
        _rigidbody2D = playerController.transform.GetComponent<Rigidbody2D>();
    }
    public void MoveTick(float direction, float moveSpeed)
    {
        if (direction == 0)
        {
            _rigidbody2D.velocity = Vector2.zero;
            return;
        }
        _rigidbody2D.velocity = Vector2.up * direction * Time.deltaTime * moveSpeed;
    }


}
