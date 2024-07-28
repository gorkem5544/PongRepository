using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Concretes
{
    public class BallBouncing : IBallBouncing
    {
        Collision2D _collision2D;
        IBallController _ballController;
        ICharacterController _characterController;
        public BallBouncing(IBallController ballController)
        {
            _ballController = ballController;
        }
        public void GetReference(ICharacterController characterController, Collision2D collision2D)
        {
            _characterController = characterController;
            _collision2D = collision2D;
        }
        public void BoundingAction()
        {
            if (_characterController != null)
            {
                FinalVelocity(_characterController);
            }
        }
        private void FinalVelocity(ICharacterController characterController)
        {
            _ballController.Rigidbody2D.velocity = Direction(characterController) * _ballController.BallSettings.MoveSpeed;
        }
        /// <summary>
        /// Topun Rakete olan uzaklığı ölçülür ve raketin boyuna bölünür
        /// topun rakete çarptığı konuma göre 1,-1 arasında float değer döner
        /// </summary>
        float HitFactor(ICharacterController characterController)
        {
            return (_ballController.transform.position.y - characterController.transform.position.y) / _collision2D.collider.bounds.size.y;
        }
        /// <summary>
        /// Hit factor methodundan gelen fload değeri  return ettiğimiz direction ile extra olarak carpan raketin oyuncu ise 1 oyuncu değil se -1 olacak olan x parametesi sayesinde topumuz vector(x,HitFactor()) yönünde haraket edecektir 
        /// </summary>
        Vector2 Direction(ICharacterController characterController)
        {
            return new Vector2(characterController.Info, HitFactor(characterController)).normalized;
        }
    }
}