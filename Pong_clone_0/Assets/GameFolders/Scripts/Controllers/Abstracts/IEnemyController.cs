using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.EnemyScriptableObjects;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts
{
    public interface IEnemyController : ICharacterController
    {
        IScoreManager EnemyScoreManager { get; }
        EnemySettings EnemySettings { get; }
        IBallController BallController { get; }
    }

}