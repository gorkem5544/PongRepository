using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts
{
    public interface IBallController : IEntityController
    {
        Rigidbody2D Rigidbody2D { get; }
    }

}