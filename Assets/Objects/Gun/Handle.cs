using SupportLibrary;
using UnityEngine;

namespace Varwin.Types.Gun_0690865357b841c582e125bbb96ba339
{
    public class Handle : MonoBehaviour
    {
        [SerializeField] private WheelBehaviour _wheelBehaviour;
        
        public delegate void TurnoverHandler();
        public event TurnoverHandler Turnover;

        private void FixedUpdate()
        {
            if (_wheelBehaviour.CurrentWheelState >= 1)
            {
                _wheelBehaviour.NumberOfTurns++;
                Turnover?.Invoke();
            }
        }
    }
}