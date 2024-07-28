using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Inputs.Abstracts
{
    public interface IPlayerInput
    {
        float VerticalInput { get; }
        bool MouseClick { get; }
    }

}