using UnityEngine;

namespace Varwin.Types.BowlingBall
{
    public class BallThrowLogic
    {
        private Transform _viewDirection;

        public void GrabStart(GrabingContext context)
        {
            if (ProjectData.PlatformMode == PlatformMode.Vr) return;
            _viewDirection = context.GameObject.transform;
        }

        public void GrabEnd(Rigidbody rigidbody, float throwForce)
        {
            if (ProjectData.PlatformMode == PlatformMode.Vr) return;
            rigidbody.AddForce(_viewDirection.forward * throwForce);
        }
    }
}