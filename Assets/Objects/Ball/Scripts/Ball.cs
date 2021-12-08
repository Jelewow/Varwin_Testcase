using UnityEngine;
using Varwin.Public;

namespace Varwin.Types.BowlingBall
{
    [VarwinComponent(English: "Bowling ball", Russian: "Шар для боулинга")]
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : VarwinObject, IGrabStartAware, IGrabEndAware
    {
        [Locale(SystemLanguage.English, "Power of the throw")]
        [Locale(SystemLanguage.Russian, "Сила броска")]
        [SerializeField] private float _throwForce;

        private BallThrowLogic _ballThrowLogic;
        private Rigidbody _rigidbody;

        public float Velocity => _rigidbody.velocity.magnitude;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _ballThrowLogic = new BallThrowLogic();
        }

        public void OnGrabStart(GrabingContext context)
        {
            _ballThrowLogic.GrabStart(context);
        }

        public void OnGrabEnd()
        {
            _ballThrowLogic.GrabEnd(_rigidbody, _throwForce);
        }
    }
}