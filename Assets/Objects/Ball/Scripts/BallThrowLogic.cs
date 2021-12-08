using UnityEngine;

namespace Varwin.Types.BowlingBall
{
    public class BallThrowLogic
    {
        private Camera _playerCamera;
        private Transform _viewDirection;
        
        public void GrabStart(GrabingContext context)
        {
            _viewDirection = context.GameObject.transform;
        }

        public void GrabEnd(Rigidbody rigidbody, float throwForce)
        {
            rigidbody.AddForce(_viewDirection.forward * throwForce);
        }
    }
}