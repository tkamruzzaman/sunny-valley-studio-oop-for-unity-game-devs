using UnityEngine;
using UnityEngine.Events;

namespace HealthSystem
{
    public class Health : MonoBehaviour, IHittable
    {
        [field: SerializeField]
        public int CurrentHealth { get; private set; }

        public UnityEvent OnDeath, OnHit;

        public void InitializeHealth(int startingHealth)
        {
            if (startingHealth < 0)
                startingHealth = 0;

            CurrentHealth = startingHealth;
        }

        public void GetHit(int damageValue, GameObject sender)
        {
            CurrentHealth -= damageValue;

            if (CurrentHealth <= 0)
            {
                OnDeath?.Invoke();
            }
            else
            {
                OnHit?.Invoke();
            }
        }
    }
}