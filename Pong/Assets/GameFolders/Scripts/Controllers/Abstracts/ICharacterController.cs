using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts
{
    public interface ICharacterController : IEntityController
    {
        int Info { get; }
    }
}