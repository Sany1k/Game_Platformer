using UnityEngine;

namespace Platformer.Components
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int coinValue;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CoinsWallet.instance.AddCoin(coinValue);

                FindObjectOfType<AudioManager>().Play("CollectCoin");
            }
        }
    }
}
