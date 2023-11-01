using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts
{
    public interface IMover
    {
        void MoveTick(float direction, float moveSpeed);
    }

}