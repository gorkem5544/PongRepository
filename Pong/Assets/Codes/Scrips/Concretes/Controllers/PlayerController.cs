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
        _launchingBall = new LaunchingBall(this);
        _playerInput = new PlayerInput();
        _mover = new MoveWithTranslate(this);

    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_playerInput.MouseClick);
        _launchingBall.LaunchBall();
    }
    private void FixedUpdate()
    {
        _mover.MoveTick(_playerInput.VerticalInput, _playerSO.MoveSpeed);
    }
}
