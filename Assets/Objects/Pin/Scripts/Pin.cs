using System;
using UnityEngine;
using Varwin.Public;

namespace Varwin.Types.BowlingPin
{
    [VarwinComponent("Pin", Russian: "Кегля")]
    [RequireComponent(typeof(PinCollisionHandler))]
    [RequireComponent(typeof(Rigidbody))]
    public class Pin : VarwinObject
    {
        [SerializeField] private float _mass;
        
        private PinCollisionHandler _collisionHandler;
        private Rigidbody _rigidbody;

        [Variable("Mass", Russian: "Масса")]
        public float Mass { get => _mass; set => _mass = value; }
        
        [Checker("Is pin stay", Russian:"Стоит ли кегля")]
        public bool IsStay() => _collisionHandler.IsStay;

        [Event("Pin fallen", Russian:"Кегля упала")]
        public event Action PinFallen;
        
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