using UnityEngine;

namespace Platformer.Components
{
    public class DestroyObject : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToDestroy;

        public void DestroyComponent()
        {
            Destroy(_objectToDestroy);
        }
    }
}
