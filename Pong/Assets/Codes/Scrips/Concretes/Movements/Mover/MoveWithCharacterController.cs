using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCharacterController : IMover
{
    CharacterController _characterController;
    public MoveWithCharacterController(IPlayerController playerController)
    {
        _characterController = playerController.transform.GetComponent<CharacterController>();
    }
    public void MoveTick(float direction, float moveSpeed)
    {
        if (direction == 0)
        {
            return;
        }
        _characterController.Move(Vector2.up * direction * Time.deltaTime * moveSpeed);
    }
}
