using UnityEngine;
using Varwin.Types.BowlingBall;

namespace Varwin.Types.BowlingPin
{
    [RequireComponent(typeof(PinCollisionHandler))]
    public class PinVFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _hitVFX;
        [SerializeField] private ParticleSystem _fallVFX;

        private PinCollisionHandler _collisionHandler;

        private void Awake()
        {
            _collisionHandler = GetComponent<PinCollisionHandler>();
        }

        private void OnCollisionEnter(Collision other)
        {
            bool isBall = other.gameObject.GetComponent<Bowl>() != null;
            if (!isBall) return;

            _hitVFX.Play();
        }

        private void OnEnable()
        {
            _collisionHandler.PinFallen += OnPinFallen;
        }
        
        private void OnDisable()
        {
            _collisionHandler.PinFallen -= OnPinFallen;
        }

        private void OnPinFallen()
        {
            _fallVFX.Play();
            enabled = false;
        }
    }
}