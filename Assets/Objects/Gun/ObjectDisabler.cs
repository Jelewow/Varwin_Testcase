using System.Collections;
using UnityEngine;

namespace Varwin.Types.Gun_0690865357b841c582e125bbb96ba339
{
    public class ObjectDisabler : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            StartCoroutine(DisableDelay());
        }

        private IEnumerator DisableDelay()
        {
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        } 
    }
}