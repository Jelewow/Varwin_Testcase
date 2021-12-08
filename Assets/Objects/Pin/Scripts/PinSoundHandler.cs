using UnityEngine;
using Varwin.Types.BowlingBall;

namespace Varwin.Types.BowlingPin
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(PinCollisionHandler))]
    public class PinSoundHandler : MonoBehaviour
    {
        private const int MinVolume = 0;
        private const int MaxVolume = 1;
        private const int SpeedNormalizeFactor = 4;
        
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
            Ball ball = other.gameObject.GetComponent<Ball>();
            if (ball == null) return;

            float volume = Mathf.Clamp(ball.Velocity / SpeedNormalizeFactor, MinVolume, MaxVolume);
            PlaySound(_hit, volume);
        }

        private void OnPinFallen()
        {
            PlaySound(_fall, MaxVolume);
        }

        private void PlaySound(AudioClip sound, float volume)
        {
            _audioSource.volume = volume;
            _audioSource.PlayOneShot(sound, volume);
        }
    }
}