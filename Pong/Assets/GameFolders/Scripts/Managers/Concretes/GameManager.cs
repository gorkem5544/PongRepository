using System.Collections;

using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.PlayerControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class GameManager : SingletonDontDestroyMono<GameManager>
    {
        public enum GameManagerStateEnum
        {
            Menu, GameStarting, LaunchBall, Game, GameWin, GameOver, GameRestart, ReturnMenu
        }
        IStateMachine _stateMachine;
        public GameManagerStateEnum GameState { get; set; }
        public bool IsGameStarting { get; set; }





        [SerializeField] PlayerController _playerController;
        IPlayerController PlayerController => _playerController;

        [SerializeField] BallController _ballController;

        LaunchingBall _launchingBall;
        Vector2 _playerStartingPosition, _ballStartingPosition, _enemyStartingPosition;

        public Vector2 PlayerStartingPosition { get => _playerStartingPosition; set => _playerStartingPosition = value; }
        public Vector2 BallStartingPosition { get => _ballStartingPosition; set => _ballStartingPosition = value; }
        public Vector2 EnemyStartingPosition { get => _enemyStartingPosition; set => _enemyStartingPosition = value; }

        public bool _isGameSTarting;

        protected override void Awake()
        {
            base.Awake();
            _launchingBall = new LaunchingBall(_ballController);
            _stateMachine = new StateMachine();
        }
        private void Start()
        {
            GameState = GameManagerStateEnum.Menu;
            PlayerStartingPosition = new Vector2(-7, 0);
            BallStartingPosition = Vector2.zero;
            _enemyStartingPosition = new Vector2(7, 0);

            GameManagerGameMenuState gameManagerGameMenuState = new GameManagerGameMenuState();
            GameManagerLaunchBallState gameManagerLaunchBallState = new GameManagerLaunchBallState();
            GameManagerGameStartingState gameManagerGameStartingState = new GameManagerGameStartingState();
            GameManagerGameState gameManagerGameState = new GameManagerGameState();
            GameManagerGameWinState gameManagerGameWinState = new GameManagerGameWinState();
            GameManagerGameOverState gameManagerGameOverState = new GameManagerGameOverState();

            GameManagerGameRestartState gameManagerGameRestartState = new GameManagerGameRestartState();
            GameManagerReturnMenuState gameManagerReturnMenuState = new GameManagerReturnMenuState();


            _stateMachine.SetState(gameManagerGameMenuState);
            _stateMachine.AddTransition(gameManagerGameMenuState, gameManagerGameStartingState, () => GameState == GameManagerStateEnum.GameStarting);
            _stateMachine.AddTransition(gameManagerGameStartingState, gameManagerLaunchBallState, () => GameState == GameManagerStateEnum.LaunchBall);
            _stateMachine.AddTransition(gameManagerLaunchBallState, gameManagerGameState, () => GameState == GameManagerStateEnum.Game);

            _stateMachine.AddTransition(gameManagerGameState, gameManagerGameOverState, () => GameState == GameManagerStateEnum.GameOver);
            _stateMachine.AddTransition(gameManagerGameState, gameManagerGameWinState, () => GameState == GameManagerStateEnum.GameWin);


            _stateMachine.AddAnyState(gameManagerReturnMenuState, () => GameState == GameManagerStateEnum.ReturnMenu);
            _stateMachine.AddAnyState(gameManagerGameRestartState, () => GameState == GameManagerStateEnum.GameRestart);

            _stateMachine.AddTransition(gameManagerReturnMenuState, gameManagerGameMenuState, () => GameState == GameManagerStateEnum.Menu);
            _stateMachine.AddTransition(gameManagerGameRestartState, gameManagerGameStartingState, () => GameState == GameManagerStateEnum.GameStarting);




        }

        private void Update()
        {
            _stateMachine.Update();
        }
        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }




    }

}

public class GameManagerGameMenuState : IState
{
    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {
        Debug.Log("menu");
    }
}
public class GameManagerLaunchBallState : IState
{
    public void Enter()
    {
        Debug.Log("Lauınh");
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {
        Debug.Log("Lauınh");

    }
}
public class GameManagerGameStartingState : IState
{
    public void Enter()
    {
        Debug.Log("Game Starting");
    }

    public void Exit()
    {
        Debug.Log("Game Starting Exit");

    }

    public void FixedUpdate()
    {
        Debug.Log("Game Starting Fixe");

    }

    public void Update()
    {
        Debug.Log("Game Starting Update");

    }
}
public class GameManagerGameState : IState
{
    public void Enter()
    {
        Debug.Log("Game enter");
    }

    public void Exit()
    {
        Debug.Log("Game  Exit");

    }

    public void FixedUpdate()
    {
        Debug.Log("Game  Fixe");

    }

    public void Update()
    {
        Debug.Log("Game  Update");

    }
}
public class GameManagerGameWinState : IState
{
    public void Enter()
    {
        Debug.Log("Win");
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {
        Debug.Log("win");

    }
}
public class GameManagerGameOverState : IState
{
    public void Enter()
    {
        Debug.Log("over");
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {
        Debug.Log("over");

    }
}
public class GameManagerGameRestartState : IState
{
    public void Enter()
    {
        GameManager.Instance.GameState = GameManager.GameManagerStateEnum.GameStarting;
        Debug.Log("Res");
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {
        Debug.Log("Res");

    }
}
public class GameManagerReturnMenuState : IState
{
    public void Enter()
    {
        Debug.Log("ReturnMenu");
        GameManager.Instance.GameState = GameManager.GameManagerStateEnum.Menu;
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {
        Debug.Log("ReturnMenu");

    }
}