using UnityEngine;

/// <summary>
/// Simple health handler for units.
/// </summary>
public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool IsAlive => currentHealth > 0;

    public delegate void DeathHandler();
    public event DeathHandler OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(int amount)
    {
        if (!IsAlive)
            return;

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath?.Invoke();
        }
    }
}
