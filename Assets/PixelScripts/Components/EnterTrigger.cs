using UnityEngine;
using UnityEngine.Events;

namespace Platformer.Components
{
    public class EnterTrigger : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private UnityEvent _action;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(_tag))
            {
                _action?.Invoke();
            }
        }
    }
}
