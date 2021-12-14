using UnityEngine;
using Varwin;
using Varwin.Public;

namespace Varwin.Types.Pin_75bf49caa4044986ba886e3de485b800
{
    [RequireComponent(typeof(Rigidbody))]
    [VarwinComponent(English: "Pin", Russian: "Кегля")]
    public class Pin : VarwinObject
    {
        [SerializeField] private float _mass;

        private PinCollisionHandler _collisionHandler;
        private Rigidbody _rigidbody;

        [Variable(English: "Mass", Russian: "Масса")]
        public float Mass
        {
            get => _mass;
            internal set => _mass = value;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _rigidbody.mass = Mass;
        }
    }
}
