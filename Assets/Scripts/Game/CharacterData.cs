using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data describing a hero character used by the player.
/// </summary>
[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Characters/Character Data")]
public class CharacterData : ScriptableObject
{
    public GameObject modelPrefab;
    public int health;
    public int attack;
    public int defense;
    public List<PerkData> passivePerks = new();
}
