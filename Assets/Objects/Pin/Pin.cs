using UnityEngine;
using Varwin;
using Varwin.Public;

namespace Varwin.Types.Pin_75bf49caa4044986ba886e3de485b800
{
    [RequireComponent(typeof(PinCollisionHandler))]
    [RequireComponent(typeof(Rigidbody))]
    [VarwinComponent(English: "Pin", Russian: "Кегля")]
    public class Pin : VarwinObject
    {
        [SerializeField] private float _mass;

        private PinCollisionHandler _collisionHandler;
        private Rigidbody _rigidbody;

        public delegate void FallHandler();

        [Variable(English: "Mass", Russian: "Масса")]
        public float Mass
        {
            get => _mass;
            internal set => _mass = value;
        }

        [Checker(English: "Is pin stay", Russian: "Стоит ли кегля")]
        public bool IsStay() => _collisionHandler.IsStay;

        [Event(English: "Pin fallen", Russian: "Кегля упала")]
        public event FallHandler PinFallen;

        private void Awake()
        {
            _collisionHandler = GetComponent<PinCollisionHandler>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _rigidbody.mass = Mass;
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
            PinFallen?.Invoke();
        }
    }
}
