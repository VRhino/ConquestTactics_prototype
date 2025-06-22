using System.Collections;
using UnityEngine;

/// <summary>
/// Coordinates the battle flow, checking for victory or defeat conditions
/// and broadcasting the final result.
/// </summary>
public class BattleManager : MonoBehaviour
{
    /// <summary>
    /// Global access to the active BattleManager instance.
    /// </summary>
    public static BattleManager Instance { get; private set; }

    /// <summary>
    /// Possible states of the battle lifecycle.
    /// </summary>
    public enum BattleState { NotStarted, Ongoing, Victory, Defeat }

    /// <summary>
    /// Current battle state, read only for other systems.
    /// </summary>
    public BattleState CurrentState { get; private set; } = BattleState.NotStarted;

    /// <summary>
    /// Event invoked when the battle finishes.
    /// </summary>
    public event System.Action<BattleState> OnBattleEnd;

    private bool hasBattleEnded;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        StartBattle();
    }

    /// <summary>
    /// Prepares the scene and switches the manager to the Ongoing state.
    /// </summary>
    private void StartBattle()
    {
        ChangeState(BattleState.Ongoing);
        if (BattleTimer.Instance != null)
            BattleTimer.Instance.StartTimer();
        StartCoroutine(MonitorBattleConditions());
    }

    /// <summary>
    /// Periodically verifies victory or defeat conditions.
    /// </summary>
    private IEnumerator MonitorBattleConditions()
    {
        while (!hasBattleEnded)
        {
            yield return new WaitForSeconds(1f);

            if (CurrentState != BattleState.Ongoing)
                continue;

            if (SquadManager.Instance != null && SquadManager.Instance.HasNoUnits())
            {
                EndBattle(BattleState.Defeat);
                yield break;
            }

            if (EnemyManager.Instance != null && EnemyManager.Instance.AreAllDead())
            {
                EndBattle(BattleState.Victory);
                yield break;
            }

#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.F10))
            {
                EndBattle(BattleState.Victory);
                yield break;
            }
            if (Input.GetKeyDown(KeyCode.F11))
            {
                EndBattle(BattleState.Defeat);
                yield break;
            }
#endif
        }
    }

    /// <summary>
    /// Finalizes the battle and notifies subscribers.
    /// </summary>
    private void EndBattle(BattleState result)
    {
        if (hasBattleEnded)
            return;

        hasBattleEnded = true;
        if (BattleTimer.Instance != null)
            BattleTimer.Instance.StopTimer();
        ChangeState(result);
        Debug.Log($"Battle ended with result: {result}");

        BattleResultData data = BuildResultData(result);

        OnBattleEnd?.Invoke(result);
        EndBattleHandler.HandleBattleEnd(result);

        // Optionally forward results to any UI component listening.
        var ui = FindObjectOfType<BattleResultsUI>();
        if (ui != null)
            ui.ShowResults(data);
    }

    /// <summary>
    /// Gathers final information used for the results screen.
    /// </summary>
    private BattleResultData BuildResultData(BattleState result)
    {
        float time = BattleTimer.GetElapsedTime();
        string name = GetSquadName();

        int initial = GetInitialTroopCount();
        int survivors = GetSurvivingTroopCount();

        return new BattleResultData
        {
            result = result,
            squadName = name,
            unitsInitial = initial,
            unitsRemaining = survivors,
            battleDuration = time,
            enemiesDefeated = 0
        };
    }

    /// <summary>
    /// Delegate for other systems to obtain the current squad name.
    /// </summary>
    public string GetSquadName()
    {
        return SquadManager.Instance != null && SquadManager.Instance.activeSquad != null && SquadManager.Instance.activeSquad.Loadout != null
            ? SquadManager.Instance.activeSquad.Loadout.name
            : string.Empty;
    }

    private int GetInitialTroopCount()
    {
        if (SquadManager.Instance == null || SquadManager.Instance.activeSquad == null || SquadManager.Instance.activeSquad.Loadout == null)
            return 0;

        int count = 0;
        foreach (var t in SquadManager.Instance.activeSquad.Loadout.troops)
        {
            if (t != null)
                count += t.unitCount;
        }
        return count;
    }

    /// <summary>
    /// Forces the battle to end in defeat.
    /// </summary>
    public void ForceDefeat(string reason)
    {
        Debug.Log($"BattleManager forced defeat: {reason}");
        EndBattle(BattleState.Defeat);
    }

    private int GetSurvivingTroopCount()
    {
        return SquadManager.Instance != null ? SquadManager.Instance.GetActiveUnits().Count : 0;
    }

    private void ChangeState(BattleState newState)
    {
        if (CurrentState == newState)
            return;

        CurrentState = newState;
        Debug.Log($"BattleManager state changed to {newState}");
    }
}
