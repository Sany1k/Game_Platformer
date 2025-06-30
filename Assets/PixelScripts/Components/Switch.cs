using UnityEngine;

namespace Platformer.Components
{
    public class Switch : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _state;
        [SerializeField] private string animationKey;

        public void ToSwitch()
        {
            _state = !_state;
            _animator.SetBool(animationKey, _state);
        }

        public void SwitchIt()
        {
            ToSwitch();
        }
    }
}
