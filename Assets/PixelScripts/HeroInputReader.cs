using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        public void OnMovement(InputAction.CallbackContext context)
        {
            var dir = context.ReadValue<Vector2>();
            _hero.SetDirection(dir);
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero.Interact();
            }
        }
    }
}
