using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Container class for all locally stored player profile information.
/// Serializable to allow future JSON persistence.
/// </summary>
[System.Serializable]
public class PlayerProfileData
{
    public string playerId;
    public string playerName;
    public List<HeroData> heroes = new();
    public List<SquadLoadout> unlockedSquads = new();
    public SquadLoadout activeSquad;
    public HeroData activeHero;
    public List<PerkData> perksPasivos = new();
}
