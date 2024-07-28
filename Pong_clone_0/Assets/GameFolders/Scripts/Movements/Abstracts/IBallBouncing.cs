using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts
{
    public interface IBallBouncing
    {
        void GetReference(ICharacterController characterController, Collision2D collision2D);
        void BoundingAction();
    }

}