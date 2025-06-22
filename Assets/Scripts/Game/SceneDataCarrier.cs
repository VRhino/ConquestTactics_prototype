using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Transient data container used to pass information between scenes at runtime.
/// Does not handle any persistence and gets cleared manually when no longer needed.
/// </summary>
public class SceneDataCarrier : MonoBehaviour
{
    /// <summary>
    /// Global access to the carrier instance if present.
    /// </summary>
    public static SceneDataCarrier Instance { get; private set; }

    /// <summary>
    /// Currently active hero selected by the player.
    /// </summary>
    public HeroData activeHero { get; set; }

    /// <summary>
    /// Squad chosen to enter the next battle.
    /// </summary>
    public SquadLoadout selectedSquad { get; set; }

    /// <summary>
    /// Results from the last battle played.
    /// </summary>
    public BattleResultData lastBattleResult { get; set; }

    /// <summary>
    /// Name of the scene the player came from.
    /// </summary>
    public string originScene { get; set; }

    /// <summary>
    /// Additional arbitrary data that systems may exchange.
    /// </summary>
    public Dictionary<string, object> customPayload { get; set; } = new();

    /// <summary>
    /// Indicates if the player entered a match via matchmaking.
    /// </summary>
    public bool cameFromMatchmaking { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("SceneDataCarrier awake and ready");
    }

    /// <summary>
    /// Clears all stored data.
    /// </summary>
    public void Clear()
    {
        activeHero = null;
        selectedSquad = null;
        lastBattleResult = null;
        originScene = null;
        cameFromMatchmaking = false;
        customPayload.Clear();
        Debug.Log("SceneDataCarrier cleared");
    }
}
