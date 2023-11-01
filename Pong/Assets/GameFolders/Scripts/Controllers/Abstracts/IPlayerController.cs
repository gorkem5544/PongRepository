using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Inputs.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts
{
    public interface IPlayerController : IEntityController
    {
        IMover Mover { get; }
        IPlayerSO PlayerSO { get; }
        IPlayerInput PlayerInput { get; }
        //IBallController BallController { get; }
    }

}