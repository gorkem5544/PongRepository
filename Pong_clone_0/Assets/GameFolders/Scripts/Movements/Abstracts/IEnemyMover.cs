using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts
{
    public interface IEnemyMover
    {
        void MoveUpdate();
        void FixedUpdate();
    }

}