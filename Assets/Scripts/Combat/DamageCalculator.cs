using UnityEngine;

public static class DamageCalculator
{
    public static int CalculateDamage(CombatStats attacker, DefenseStats defender)
    {
        if (attacker == null || defender == null)
            return 0;

        float resistance = 0f;
        switch (attacker.damageType)
        {
            case PhysicalDamageType.Slashing:
                resistance = defender.slashingResistance;
                break;
            case PhysicalDamageType.Piercing:
                resistance = defender.piercingResistance;
                break;
            case PhysicalDamageType.Blunt:
                resistance = defender.bluntResistance;
                break;
        }

        float mitigated = Mathf.Clamp01(resistance - attacker.penetration);
        float finalMultiplier = 1f - mitigated;
        int finalDamage = Mathf.Max(Mathf.RoundToInt(attacker.baseDamage * finalMultiplier), 0);
        return finalDamage;
    }
}
