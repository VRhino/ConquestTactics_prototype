using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the current player's profile in memory.
/// Provides quick access to character and squad data.
/// </summary>
public static class PlayerProfileManager
{
    public static PlayerData CurrentProfile { get; private set; }

    public static void Initialize(PlayerData data)
    {
        CurrentProfile = data;
    }

    public static CharacterData GetActiveCharacter() => CurrentProfile?.activeCharacter;

    public static List<SquadLoadout> GetUnlockedSquads() =>
        CurrentProfile != null ? CurrentProfile.unlockedSquads : new List<SquadLoadout>();
}
