using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerController : IEntityController
{
    IMover Mover { get; }
    IPlayerSO PlayerSO { get; }
    IPlayerInput PlayerInput { get; }
    BallController BallController{get;}
}
