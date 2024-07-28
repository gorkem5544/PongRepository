using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.OtherScriptableObjects;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts
{
    public interface IBallController : IEntityController
    {
        Rigidbody2D Rigidbody2D { get; }
        BallSettings BallSettings { get; }
    }

}