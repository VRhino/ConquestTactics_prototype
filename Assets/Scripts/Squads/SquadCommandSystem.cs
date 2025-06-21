using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Allows the player to issue basic commands to the active squad.
/// </summary>
public class SquadCommandSystem : MonoBehaviour
{
    public enum CommandType
    {
        FollowMe,
        HoldPosition,
        AttackTarget
    }

    [Tooltip("Reference to the squad manager handling the active squad")] 
    public SquadManager squadManager;

    /// <summary>
    /// Sends a command to every unit in the active squad.
    /// </summary>
    /// <param name="command">Type of command to issue.</param>
    /// <param name="target">Optional target transform used for AttackTarget.</param>
    public void IssueCommand(CommandType command, Transform target = null)
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
                case CommandType.FollowMe:
                    unit.SetFormationMode(true);
                    break;
                case CommandType.HoldPosition:
                    unit.SetFormationMode(false);
                    ai.SetToHoldPosition();
                    break;
                case CommandType.AttackTarget:
                    if (target != null)
                        ai.SetTarget(target);
                    break;
            }
        }
    }
}
