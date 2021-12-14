using UnityEngine;

namespace Varwin.Types.Pin_75bf49caa4044986ba886e3de485b800
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
            Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
            if (rigidbody == null) return;
            if (rigidbody.velocity.magnitude <= 0) return;

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