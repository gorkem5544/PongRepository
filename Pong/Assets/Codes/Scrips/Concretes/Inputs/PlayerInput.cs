using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : IPlayerInput
{
    DefaultInput _inputs;
    public float VerticalInput { get; private set; }

    public bool MouseClick { get; private set; }

    public PlayerInput()
    {
        _inputs = new DefaultInput();
        _inputs.Player.Vertical.performed += context => VerticalInput = context.ReadValue<float>();
        _inputs.Player.MouseClick.performed += context => MouseClick = context.ReadValueAsButton();
        _inputs.Enable();

    }
}
