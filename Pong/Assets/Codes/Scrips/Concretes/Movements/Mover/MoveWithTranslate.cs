using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTranslate : IMover
{
    IPlayerController _playerController;

    public MoveWithTranslate(IPlayerController playerController)
    {
        _playerController = playerController;
    }
    public void MoveTick(float direction, float moveSpeed)
    {
        if (direction == 0)
        {
            return;
        }
        _playerController.transform.Translate(Vector2.up * direction * Time.deltaTime * moveSpeed);
        float yBoundary = Math.Clamp(_playerController.transform.position.y, -3, 3);
        _playerController.transform.position = new Vector3(_playerController.transform.position.x, yBoundary, 0);
    }

}
