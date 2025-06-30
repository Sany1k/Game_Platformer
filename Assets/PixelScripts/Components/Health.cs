using UnityEngine;
using UnityEngine.Events;

namespace Platformer.Components
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private HealthBar healthBar;

        private int currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        public void ApplyDamage(int damageValue)
        {
            currentHealth -= damageValue;
            _onDamage?.Invoke();
            FindObjectOfType<AudioManager>().Play("GetDamage");
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                _onDie?.Invoke();
                FindObjectOfType<AudioManager>().Play("PlayerDead");
            }
        }
    }
}
