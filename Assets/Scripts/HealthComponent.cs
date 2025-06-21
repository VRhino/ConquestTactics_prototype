using UnityEngine;
using TMPro;

/// <summary>
/// Simple health handler for units.
/// </summary>
public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Damage Visuals")]
    public GameObject floatingDamagePrefab;
    public Color normalColor = Color.white;
    public Color criticalColor = Color.yellow;
    public Color abilityColor = Color.cyan;

    [Tooltip("Animator used for death animation")] public Animator animator;

    public bool IsAlive => currentHealth > 0;

    public delegate void DeathHandler();
    public event DeathHandler OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }


    public void ApplyDamage(int amount, DamageVisualType type = DamageVisualType.Normal)
    {
        if (!IsAlive)
            return;

        currentHealth -= amount;
        ShowFloatingDamage(amount, type);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke();
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
        Destroy(gameObject, 2f);
    }

    /// <summary>
    /// Spawns a floating damage number above the unit.
    /// </summary>
    public void ShowFloatingDamage(int amount, DamageVisualType type)
    {
        if (floatingDamagePrefab == null)
            return;

        GameObject instance = Instantiate(floatingDamagePrefab, transform.position + Vector3.up, Quaternion.identity);

        var text = instance.GetComponentInChildren<TMPro.TMP_Text>();
        if (text != null)
        {
            text.text = amount.ToString();
            text.color = GetColorForType(type);
        }
    }

    private Color GetColorForType(DamageVisualType type)
    {
        return type switch
        {
            DamageVisualType.Critical => criticalColor,
            DamageVisualType.Ability => abilityColor,
            _ => normalColor,
        };
    }
}
