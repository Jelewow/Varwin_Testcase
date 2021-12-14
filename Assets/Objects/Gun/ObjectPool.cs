using System.Collections.Generic;
using UnityEngine;

namespace Varwin.Types.Gun_0690865357b841c582e125bbb96ba339
{
    public class ObjectPool : MonoBehaviour
    {
        private readonly List<GameObject> _pool = new List<GameObject>();
        private readonly Dictionary<GameObject, Rigidbody> _physicPool = new Dictionary<GameObject, Rigidbody>();

        [SerializeField] private GameObject _template;
        [SerializeField] private int _capacity;
        [SerializeField] private Transform _parent;


        private void Awake()
        {
            for (int i = 0; i < _capacity; i++)
            {
                var gameObject = Instantiate(_template, transform.position, Quaternion.identity);
                var rigidbody = gameObject.GetComponent<Rigidbody>();
                gameObject.SetActive(false);
                _pool.Add(gameObject);
                _physicPool.Add(gameObject, rigidbody);
            }
        }

        public bool TryGetDisabledObject(out Rigidbody rigidbody)
        {
            foreach (GameObject item in _pool)
            {
                if (item.activeSelf == false)
                {
                    item.SetActive(true);
                    item.transform.position = _parent.transform.position;
                    rigidbody = _physicPool[item];
                    return true;
                }
            }

            rigidbody = null;
            return false;
        }
    }
}