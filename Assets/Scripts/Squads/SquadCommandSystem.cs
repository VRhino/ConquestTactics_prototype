using UnityEngine;
using System.Collections.Generic;
using TMPro;

/// <summary>
/// Allows the player to issue basic commands to the active squad.
/// </summary>
public class SquadCommandSystem : MonoBehaviour
{
    public enum SquadCommand
    {
        Follow,
        HoldPosition,
        AttackTarget
    }

    [Tooltip("Reference to the squad manager handling the active squad")]
    public SquadManager squadManager;

    [Tooltip("Optional text element to display issued commands")]
    public TMP_Text feedbackText;

    /// <summary>
    /// Sends a command to every unit in the active squad.
    /// </summary>
    /// <param name="command">Type of command to issue.</param>
    /// <param name="target">Optional target transform used for AttackTarget.</param>
    public void IssueCommand(SquadCommand command, Transform target = null)
    {
        if (squadManager == null)
            squadManager = SquadManager.Instance;

        if (squadManager == null || squadManager.activeSquad == null)
        {
            Debug.LogWarning("No active squad available to receive commands.");
            return;
        }

        IReadOnlyList<UnitController> units = squadManager.GetActiveUnits();
        foreach (var unit in units)
        {
            if (unit == null)
                continue;

            var ai = unit.GetComponent<UnitAIController>();
            if (ai == null)
                continue;

            switch (command)
            {
                case SquadCommand.Follow:
                    unit.SetFormationMode(true);
                    ai.SetFollowMode(true);
                    ai.ForceState(UnitAIController.AIState.MovingToFormation);
                    break;
                case SquadCommand.HoldPosition:
                    unit.SetFormationMode(false);
                    ai.SetFollowMode(false);
                    ai.ForceState(UnitAIController.AIState.Idle);
                    break;
                case SquadCommand.AttackTarget:
                    if (target != null)
                    {
                        ai.SetTarget(target);
                    }
                    break;
            }
        }

        ShowFeedback($"Issued command: {command}");
    }

    private void ShowFeedback(string message)
    {
        if (feedbackText != null)
            feedbackText.text = message;
        Debug.Log(message);
    }
}
