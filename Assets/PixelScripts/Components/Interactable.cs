using UnityEngine;
using UnityEngine.Events;

namespace Platformer.Components
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;

        public void Interact()
        {
            _action?.Invoke();
        } 
    }
}
