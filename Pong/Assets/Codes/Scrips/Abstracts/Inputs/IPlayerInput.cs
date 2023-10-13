using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Concretes.Inputs
{

    public interface IPlayerInput
    {
        float VerticalInput { get; }
        bool MouseClick { get; }
    }

}