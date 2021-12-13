using UnityEngine;

namespace Varwin.Types.Pin_75bf49caa4044986ba886e3de485b800
{
    public class PinCollisionHandler : MonoBehaviour
    {
        private const float FallAngle = 45f;

        public bool IsStay { get; private set; }

        public delegate void FallHandler();
        
        public event FallHandler PinFallen;
        
        private void FixedUpdate()
        {
            CheckFalling();
        }

        private void CheckFalling()
        {
            float currentAngle = Vector3.Angle(transform.up, Vector3.up);
            IsStay = currentAngle >= FallAngle;
            if (!IsStay) return;

            PinFallen?.Invoke();
            enabled = false;
        }
        
        private void OnDisable() {}
    }
}