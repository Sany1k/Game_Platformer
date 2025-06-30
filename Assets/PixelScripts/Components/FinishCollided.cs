using UnityEngine;

namespace Platformer.Components
{
    public class FinishCollided : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<AudioManager>().Play("GameFinished");
                Destroy(gameObject);
            }
        }
    }
}
