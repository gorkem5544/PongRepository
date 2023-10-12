using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour, IPlayerController
{

    LaunchingBall _launchingBall;

    IMover _mover;
    public IMover Mover => _mover;

    [SerializeField] PlayerSO _playerSO;
    public IPlayerSO PlayerSO => _playerSO;

    IPlayerInput _playerInput;
    public IPlayerInput PlayerInput => _playerInput;

    [SerializeField] BallController _ballController;
    public BallController BallController => _ballController;

    private void Awake()
    {
        //_launchingBall = new LaunchingBall(this);
        _playerInput = new PlayerInput();
        _mover = new MoveWithTranslate(this);

    }

    private void FixedUpdate()
    {
        _mover.MoveTick(_playerInput.VerticalInput, _playerSO.MoveSpeed);

    }
}
