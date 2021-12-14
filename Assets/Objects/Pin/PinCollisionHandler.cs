using UnityEngine;

namespace Varwin.Types.Pin_75bf49caa4044986ba886e3de485b800
{
    public class PinCollisionHandler : MonoBehaviour
    {
        private const float FallAngle = 45f;

        private bool _isStay;

        [Checker(English: "Is pin stay", Russian: "Стоит ли кегля")]
        public bool IsStay() => _isStay;

        public delegate void FallHandler();
        
        [Event(English: "Pin fallen", Russian: "Кегля упала")]
        public event FallHandler PinFallen;
        
        private void FixedUpdate()
        {
            CheckFalling();
        }

        private void CheckFalling()
        {
            float currentAngle = Vector3.Angle(transform.up, Vector3.up);
            _isStay = currentAngle >= FallAngle;
            if (!_isStay) return;

            PinFallen?.Invoke();
            enabled = false;
        }
        
        private void OnDisable() {}
    }
}