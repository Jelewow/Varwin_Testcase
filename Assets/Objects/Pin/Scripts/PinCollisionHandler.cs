using System;
using UnityEngine;

namespace Varwin.Types.BowlingPin
{
    public class PinCollisionHandler : MonoBehaviour
    {
        private const float FallAngle = 45f;

        private int _layerMask;

        public event Action PinFallen;
        
        private void Start()
        {
            _layerMask = ~(1 << 15);
        }

        private void FixedUpdate()
        {
            FirstWayAngle();
            //SecondWayRaycast();
        }

        private void FirstWayAngle()
        {
            float angle = Vector3.Angle(transform.up, Vector3.up);
            if (!(angle >= FallAngle)) return;

            PinFallen?.Invoke();
            enabled = false;
        }

        private void SecondWayRaycast()
        {
            bool isIntersepted = Physics.Raycast(transform.position, -transform.up, 0.2f, _layerMask);
            if (isIntersepted) return;

            PinFallen?.Invoke();
            enabled = false;
        }
        
        private void OnDisable()
        {
            print("disabled");
        }
    }
}