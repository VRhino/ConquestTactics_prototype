using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CombatController : MonoBehaviour
{
    public CombatStats combatStats;

    public delegate void HitEvent(GameObject target, int damage);
    public event HitEvent OnHit;

    private void Reset()
    {
        // Ensure collider is a trigger
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DefenseStats defense = other.GetComponent<DefenseStats>();
        HealthComponent health = other.GetComponent<HealthComponent>();
        if (defense == null || health == null)
            return;

        int damage = DamageCalculator.CalculateDamage(combatStats, defense);
        health.ApplyDamage(damage, DamageVisualType.Normal);
        OnHit?.Invoke(other.gameObject, damage);
    }

    /// <summary>
    /// Attempts to apply damage directly to the given target without relying on a trigger hit.
    /// </summary>
    /// <param name="target">Target game object that owns <see cref="HealthComponent"/> and <see cref="DefenseStats"/>.</param>
    /// <param name="type">Visual damage type used by the target when displaying damage numbers.</param>
    public void TryAttack(GameObject target, DamageVisualType type = DamageVisualType.Normal)
    {
        if (target == null) return;

        DefenseStats defense = target.GetComponent<DefenseStats>();
        HealthComponent health = target.GetComponent<HealthComponent>();
        if (defense == null || health == null) return;

        int damage = DamageCalculator.CalculateDamage(combatStats, defense);
        health.ApplyDamage(damage, type);
        OnHit?.Invoke(target, damage);
    }
}
