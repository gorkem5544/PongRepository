using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonDontDestroyMono<GameManager>
{
    public enum EnumGameState
    {
        Menu, GameStarting, Game, GameWin, GameOver
    }




    public EnumGameState GameState { get; set; }


    [SerializeField] PlayerController _playerController;
    IPlayerController PlayerController => _playerController;

    [SerializeField] BallController _ballController;

    LaunchingBall _launchingBall;
    protected override void Awake()
    {
        base.Awake();
        _launchingBall = new LaunchingBall(_ballController);
    }
    private void Start()
    {
        GameState = EnumGameState.Menu;
        Debug.Log(PlayerController.PlayerInput + "+++" + _playerController + "+++" + _playerController.PlayerInput);
    }

    private void Update()
    {
        switch (GameState)
        {
            case EnumGameState.Menu:
                LevelManager.Instance.RestartAllObjectsTransform();
                /*if (PlayerController.PlayerInput.MouseClick)
                {
                    GameState = EnumGameState.GameStarting;
                }*/
                break;
            case EnumGameState.GameStarting:
                _launchingBall.LaunchBall();
                GameState = EnumGameState.Game;
                break;
            case EnumGameState.Game:
                break;
            case EnumGameState.GameWin:
                LevelManager.Instance.RestartAllObjectsTransform();
                break;

            case EnumGameState.GameOver:
                LevelManager.Instance.RestartAllObjectsTransform();
                break;
        }
        Debug.Log(GameState);
    }




}
