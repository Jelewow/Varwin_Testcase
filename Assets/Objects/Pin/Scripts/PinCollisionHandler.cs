using System;
using UnityEngine;

namespace Varwin.Types.BowlingPin
{
    public class PinCollisionHandler : MonoBehaviour
    {
        private const float FallAngle = 45f;

        public bool IsStay { get; private set; }

        public event Action PinFallen;
        
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