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
            Menu, GameStarting, LaunchBall, Game, GameWin, GameOver, GameRestart
        }
        IStateMachine _stateMachine;
        public GameManagerStateEnum GameState { get; set; }

        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            GameState = GameManagerStateEnum.Menu;
            Application.targetFrameRate = 1000;
            GameManagerGameMenuState gameManagerGameMenuState = new GameManagerGameMenuState();
            GameManagerLaunchBallState gameManagerLaunchBallState = new GameManagerLaunchBallState();
            GameManagerGameStartingState gameManagerGameStartingState = new GameManagerGameStartingState();
            GameManagerGameState gameManagerGameState = new GameManagerGameState();

            GameManagerGameWinState gameManagerGameWinState = new GameManagerGameWinState();
            GameManagerGameOverState gameManagerGameOverState = new GameManagerGameOverState();

            GameManagerGameRestartState gameManagerGameRestartState = new GameManagerGameRestartState();


            _stateMachine.SetState(gameManagerGameMenuState);
            _stateMachine.AddTransition(gameManagerGameMenuState, gameManagerGameStartingState, () => GameState == GameManagerStateEnum.GameStarting);
            _stateMachine.AddTransition(gameManagerGameStartingState, gameManagerLaunchBallState, () => GameState == GameManagerStateEnum.LaunchBall);
            _stateMachine.AddTransition(gameManagerLaunchBallState, gameManagerGameState, () => GameState == GameManagerStateEnum.Game);

            _stateMachine.AddTransition(gameManagerGameState, gameManagerGameOverState, () => GameState == GameManagerStateEnum.GameOver);
            _stateMachine.AddTransition(gameManagerGameState, gameManagerGameWinState, () => GameState == GameManagerStateEnum.GameWin);

            _stateMachine.AddTransition(gameManagerGameWinState, gameManagerGameStartingState, () => GameState == GameManagerStateEnum.GameStarting);
            _stateMachine.AddTransition(gameManagerGameWinState, gameManagerGameRestartState, () => GameState == GameManagerStateEnum.GameRestart);

            _stateMachine.AddTransition(gameManagerGameOverState, gameManagerGameRestartState, () => GameState == GameManagerStateEnum.GameRestart);
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
    private const string GameName = "Game";
    public void Enter()
    {
    }

    public void Exit()
    {
        LevelManager.Instance.LoadLevel(GameName);
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }
}
public class GameManagerLaunchBallState : IState
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
    }
}
public class GameManagerGameStartingState : IState
{
    public void Enter()
    {
        UiManager.Instance.CanTimeWork = false;
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }
}
public class GameManagerGameState : IState
{
    public void Enter()
    {
        UiManager.Instance.CanTimeWork = true;

    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }
}
public class GameManagerGameWinState : IState
{
    float _currentTime = 0;
    public void Enter()
    {
        UiManager.Instance.CanTimeWork = false;
        ParticleManager.Instance.EntityGoalParticleStart();
        SpawnerManager.Instance.NewPlayerController.PlayerScoreManager.AddScore(1);
    }

    public void Exit()
    {
        _currentTime = 0;
        SpawnerManager.Instance.RestartAllObjectsTransform();
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > 3)
        {
            GameManager.Instance.GameState = GameManager.GameManagerStateEnum.GameRestart;
        }
    }
}
public class GameManagerGameOverState : IState
{
    float _currentTime = 0;
    public void Enter()
    {
        ParticleManager.Instance.EntityGoalParticleStart();
        SpawnerManager.Instance.NewEnemyController.EnemyScoreManager.AddScore(1);
        UiManager.Instance.CanTimeWork = false;
    }

    public void Exit()
    {
        _currentTime = 0;
        SpawnerManager.Instance.RestartAllObjectsTransform();
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > 3)
        {
            GameManager.Instance.GameState = GameManager.GameManagerStateEnum.GameRestart;
        }
    }
}
public class GameManagerGameRestartState : IState
{
    public void Enter()
    {
        GameManager.Instance.GameState = GameManager.GameManagerStateEnum.GameStarting;
        SpawnerManager.Instance.RestartAllObjectsTransform();
        UiManager.Instance.CanTimeWork = true;
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }
}
