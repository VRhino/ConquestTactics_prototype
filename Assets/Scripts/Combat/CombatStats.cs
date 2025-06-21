using UnityEngine;

[System.Serializable]
public class CombatStats
{
    [Min(0)]
    public int baseDamage = 10;
    public DamageType damageType = DamageType.Slashing;
    [Range(0f, 1f)]
    public float penetration = 0f; // percentage reducing enemy resistance
}
