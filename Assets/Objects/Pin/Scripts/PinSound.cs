using UnityEngine;
using Varwin.Types.BowlingBall;

namespace Varwin.Types.BowlingPin
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(PinCollisionHandler))]
    public class PinSound : MonoBehaviour
    {
        private const int MinVolume = 0;
        private const float MaxVolume = 0.8f;
        private const int SpeedNormalizeFactor = 24;

        [SerializeField] private AudioClip _hit;
        [SerializeField] private AudioClip _fall;

        private AudioSource _audioSource;
        private PinCollisionHandler _collisionHandler;

        private void Awake()
        {
            _collisionHandler = GetComponent<PinCollisionHandler>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _collisionHandler.PinFallen += OnPinFallen;
        }

        private void OnDisable()
        {
            _collisionHandler.PinFallen -= OnPinFallen;
        }

        private void OnCollisionEnter(Collision other)
        {
            Bowl ball = other.gameObject.GetComponent<Bowl>();
            if ((object)ball == null) return;

            float volume = Mathf.Clamp(ball.Velocity / SpeedNormalizeFactor, MinVolume, MaxVolume);
            PlaySound(_hit, volume);
        }

        private void OnPinFallen()
        {
            PlaySound(_fall, MaxVolume);
        }

        private void PlaySound(AudioClip sound, float volume)
        {
            _audioSource.PlayOneShot(sound, volume);
        }
    }
}