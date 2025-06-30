using TMPro;
using UnityEngine;

namespace Platformer.Components
{
    public class CoinsWallet : MonoBehaviour
    {
        public static CoinsWallet instance;

        [SerializeField] private TextMeshProUGUI coinsValue;
        private int totalCoins = 0;

        private void Awake()
        {
            instance = this;
        }

        public void AddCoin(int count)
        {
            totalCoins += count;
            coinsValue.text = "x" + totalCoins.ToString();
        }
    }
}
