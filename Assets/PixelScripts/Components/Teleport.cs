using UnityEngine;

namespace Platformer.Components
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private Transform _destTransform;

        public void ToTeleport(GameObject target)
        {
            target.transform.position = _destTransform.position;
            FindObjectOfType<AudioManager>().Play("Teleported");
        }
    }
}
