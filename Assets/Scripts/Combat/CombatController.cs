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
        health.ApplyDamage(damage);
        OnHit?.Invoke(other.gameObject, damage);
    }
}
