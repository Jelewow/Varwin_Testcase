using System;
using UnityEngine;
using Varwin;
using Varwin.Public;

namespace Varwin.Types.Gun_0690865357b841c582e125bbb96ba339
{
    [VarwinComponent(English: "Gun", Russian: "Пушка")]
    [RequireComponent(typeof(ObjectPool))]
    public class Gun : VarwinObject
    {
        private ObjectPool _pool;
        [SerializeField] private float _force;
        
        private void Awake()
        {
            _pool = GetComponent<ObjectPool>();
        }

        public void Shoot()
        {
            if (_pool.TryGetDisabledObject(out Rigidbody rigidbody))
            {
                gameObject.SetActive(true);
                rigidbody.AddForce(transform.forward * _force);
                return;
            }
            print("empty");
        }
    }
}