using UnityEngine;
using Varwin.Public;

namespace Varwin.Types.BowlingBall
{
    [VarwinComponent("Bowling ball", Russian: "Шар для боулинга")]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public class Bowl : VarwinObject, IGrabStartAware, IGrabEndAware
    {
        [SerializeField] private float _friction;
        [SerializeField] private float _mass;
        [SerializeField] private float _throwForce;
        
        private BallThrowLogic _ballThrowLogic;
        private Rigidbody _rigidbody;
        private SphereCollider _collider;
        
        public float Velocity => _rigidbody.velocity.magnitude;

        [Variable("Throw force", Russian: "Сила броска")]
        public float ThrowForce
        {
            get => _throwForce;
            set => _throwForce = value;
        }

        [Variable("Mass", Russian: "Масса")]
        public float Mass
        {
            get => _mass;
            set => _mass = value;
        }

        [Variable("Friction", Russian: "Трение")]
        public float Friction
        {
            get => _friction;
            set => _friction = value;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<SphereCollider>();
            _ballThrowLogic = new BallThrowLogic();
        }

        private void Start()
        {
            InitParameters();
        }

        public void OnGrabStart(GrabingContext context)
        {
            _ballThrowLogic.GrabStart(context);
        }

        public void OnGrabEnd()
        {
            _ballThrowLogic.GrabEnd(_rigidbody, ThrowForce);
        }

        private void InitParameters()
        {
            _rigidbody.mass = Mass;
            _collider.sharedMaterial.dynamicFriction = Friction;
            _collider.sharedMaterial.staticFriction = Friction;
        }
    }
}