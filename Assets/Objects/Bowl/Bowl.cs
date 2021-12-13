using UnityEngine;
using Varwin.Public;

namespace Varwin.Types.BowlingBall
{
    [VarwinComponent("Bowling ball", Russian: "Шар для боулинга")]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public class Bowl : VarwinObject, IGrabStartAware, IGrabEndAware
    {
        [SerializeField] private int _friction;
        [SerializeField] private int _mass;
        [SerializeField] private int _throwForce;
        
        private BallThrowLogic _ballThrowLogic;
        private Rigidbody _rigidbody;
        private SphereCollider _collider;
        
        public float Velocity => _rigidbody.velocity.magnitude;

        [Variable(English: "Throw force", Russian: "Сила броска")]
        public int ThrowForce
        {
            get => _throwForce;
            internal set => _throwForce = value;
        }

        [Variable(English: "Mass", Russian: "Масса")]
        public int Mass
        {
            get => _mass;
            internal set => _mass = value;
        }

        [Variable(English: "Friction", Russian: "Трение")]
        public int Friction
        {
            get => _friction;
            internal set => _friction = value;
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