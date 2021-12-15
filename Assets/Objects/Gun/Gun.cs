using UnityEngine;
using Varwin.Public;

namespace Varwin.Types.Gun_0690865357b841c582e125bbb96ba339
{
    [VarwinComponent(English: "Gun", Russian: "Пушка")]
    [RequireComponent(typeof(ObjectPool))]
    public class Gun : VarwinObject
    {
        [SerializeField] private float _force;
        [SerializeField] private Handle _handle;

        private ObjectPool _pool;

        private void Awake()
        {
            _pool = GetComponent<ObjectPool>();
        }

        private void OnEnable()
        {
            _handle.Turnover += OnTurnover;
        }

        private void OnDisable()
        {
            _handle.Turnover -= OnTurnover;
        }

        private void OnTurnover()
        {
            Shoot();
        }

        private void Shoot()
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