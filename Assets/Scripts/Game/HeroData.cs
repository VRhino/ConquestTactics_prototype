using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data container describing a player's hero and its combat attributes.
/// </summary>
[System.Serializable]
public class HeroData
{
    public string heroId;
    public string name;
    public int level;

    [Header("Base attributes")]
    public int fuerza;
    public int destreza;
    public int armadura;
    public int vitalidad;

    [Header("Damage by type")]
    public int damageSlashing;
    public int damagePiercing;
    public int damageBlunt;

    [Header("Defense by type")]
    public int defenseSlashing;
    public int defensePiercing;
    public int defenseBlunt;

    public float movementSpeed;

    [Header("Passive Perks")]
    public List<PerkData> passivePerks = new();

    public Sprite icon;
    public GameObject modelPrefab;
}
