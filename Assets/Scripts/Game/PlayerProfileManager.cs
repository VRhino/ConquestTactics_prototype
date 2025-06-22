using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Singleton manager holding the local player's profile and active hero data.
/// Provides an interface for other systems to query the current squad and hero.
/// Future versions will serialize this information using JSON.
/// </summary>
public class PlayerProfileManager : MonoBehaviour
{
    public static PlayerProfileManager Instance { get; private set; }

    [Tooltip("Current player profile loaded in memory")]
    [SerializeField]
    private PlayerProfileData currentProfile;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadMockProfile();
    }

    /// <summary>
    /// Returns the hero currently selected by the player.
    /// </summary>
    public HeroData GetActiveHero() => currentProfile?.activeHero;

    /// <summary>
    /// Returns all heroes created by the player.
    /// </summary>
    public List<HeroData> GetAllHeroes() =>
        currentProfile != null ? currentProfile.heroes : new List<HeroData>();

    /// <summary>
    /// Returns all squad loadouts unlocked by the player.
    /// </summary>
    public List<SquadLoadout> GetAllLoadouts() =>
        currentProfile != null ? currentProfile.unlockedSquads : new List<SquadLoadout>();

    /// <summary>
    /// Returns the squad currently marked as active in the profile.
    /// </summary>
    public SquadLoadout GetActiveSquad() => currentProfile?.activeSquad;

    /// <summary>
    /// Sets the active squad in memory.
    /// </summary>
    public void SetActiveSquad(SquadLoadout newSquad)
    {
        if (currentProfile != null)
            currentProfile.activeSquad = newSquad;
    }

    /// <summary>
    /// Sets the active hero in memory.
    /// </summary>
    public void SetActiveHero(HeroData newHero)
    {
        if (currentProfile != null)
            currentProfile.activeHero = newHero;
    }

    /// <summary>
    /// Adds a new hero to the profile.
    /// </summary>
    public void AddHero(HeroData newHero)
    {
        if (currentProfile == null || newHero == null)
            return;
        currentProfile.heroes.Add(newHero);
    }

    /// <summary>
    /// Loads a mock profile used for local testing when no backend is present.
    /// </summary>
    public void LoadMockProfile(string playerName)
    {
        currentProfile = new PlayerProfileData
        {
            playerId = Guid.NewGuid().ToString(),
            playerName = playerName,
            unlockedSquads = new List<SquadLoadout>(),
            perksPasivos = new List<PerkData>(),
            heroes = new List<HeroData>()
        };

        // Attempt to load example assets for demonstration if available
        var defaultSquads = Resources.LoadAll<SquadLoadout>(string.Empty);
        currentProfile.unlockedSquads.AddRange(defaultSquads);
        if (currentProfile.unlockedSquads.Count > 0)
            currentProfile.activeSquad = currentProfile.unlockedSquads[0];

        var defaultHero = new HeroData
        {
            heroId = "hero_01",
            name = "Test Hero",
            level = 1,
            fuerza = 5,
            destreza = 5,
            armadura = 2,
            vitalidad = 20,
            damageSlashing = 3,
            damagePiercing = 2,
            damageBlunt = 1,
            defenseSlashing = 0,
            defensePiercing = 0,
            defenseBlunt = 0,
            movementSpeed = 5f
        };

        // Optionally populate example perks if any exist in Resources
        defaultHero.passivePerks = new List<PerkData>(Resources.LoadAll<PerkData>(string.Empty));

        currentProfile.heroes.Add(defaultHero);
        currentProfile.activeHero = defaultHero;
    }

    /// <summary>
    /// Overload that uses a default tester name.
    /// </summary>
    public void LoadMockProfile()
    {
        LoadMockProfile("Tester");
    }

    /// <summary>
    /// Serializes the current profile to disk for future persistence.
    /// </summary>
    public void SaveProfile()
    {
        if (currentProfile == null) return;
        string path = Path.Combine(Application.persistentDataPath, "player_profile.json");
        string json = JsonUtility.ToJson(currentProfile, true);
        File.WriteAllText(path, json);
    }

    /// <summary>
    /// Attempts to load a profile from disk.
    /// </summary>
    public void LoadProfile()
    {
        string path = Path.Combine(Application.persistentDataPath, "player_profile.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            currentProfile = JsonUtility.FromJson<PlayerProfileData>(json);
        }
        else
        {
            Debug.LogWarning("No saved profile found, using mock profile.");
            LoadMockProfile();
        }
    }
}
