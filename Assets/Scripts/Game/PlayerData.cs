using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Container with basic information about the player profile.
/// </summary>
[System.Serializable]
public class PlayerData
{
    public CharacterData activeCharacter;
    public List<SquadLoadout> unlockedSquads = new();
}
