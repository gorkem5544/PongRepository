using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts
{
    public interface IPlayerMover : IMoveUpdate, IMoveFixedUpdate
    {
    }
    public interface IMoveUpdate
    {
        void MoveUpdate();
    }
    public interface IMoveFixedUpdate
    {
        void FixedUpdate();
    }

}