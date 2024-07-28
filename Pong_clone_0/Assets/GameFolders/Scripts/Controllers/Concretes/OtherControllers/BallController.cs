using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.OtherScriptableObjects;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers
{
    public class BallController : MonoBehaviour, IBallController
    {
        [SerializeField] BallSettings _ballSettings;
        public BallSettings BallSettings => _ballSettings;
        Rigidbody2D _rigidbody2D;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        IBallBouncing _ballBouncing;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _ballBouncing = new BallBouncing(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            ICharacterController _characterController = other.collider.GetComponent<ICharacterController>();
            ParticleManager.Instance.BallHitParticleMethod(transform.position);

            _ballBouncing.GetReference(_characterController, other);
            _ballBouncing.BoundingAction();
        }


    }

}
