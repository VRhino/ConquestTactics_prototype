using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Example supply point that allows replacing the active squad.
/// </summary>
public class SupplyPointController : MonoBehaviour
{
    [Tooltip("Delay before the previous squad is fully destroyed")]
    public float despawnDelay = 1f;

    [Tooltip("UI shown when the player interacts with the supply point")]
    public SupplyPointInteractionUI interactionUI;

    [Tooltip("Cooldown time between interactions")]
    public float cooldown = 5f;

    // Tracks whether the point has been consumed.
    private bool used;
    // Tracks loadouts already chosen in this battle.
    private readonly HashSet<SquadLoadout> usedLoadouts = new();
    public IReadOnlyCollection<SquadLoadout> UsedLoadouts => usedLoadouts;

    private bool onCooldown;
    private bool playerInside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            if (interactionUI != null)
                interactionUI.Hide();
        }
    }

    /// <summary>
    /// Called by the player controller when interacting with the point.
    /// </summary>
    public void Interact()
    {
        if (onCooldown || !playerInside || used)
            return;

        if (interactionUI != null)
            interactionUI.ShowOptions(this);
    }

    public void ChangeSquad(SquadLoadout loadout)
    {
        if (onCooldown || loadout == null)
            return;

        StartCoroutine(ChangeSquadRoutine(loadout));
    }

    private IEnumerator ChangeSquadRoutine(SquadLoadout loadout)
    {
        onCooldown = true;
        var manager = SquadManager.Instance;
        if (manager != null)
        {
            manager.DeactivateCurrentSquad(despawnDelay);
            yield return new WaitForSeconds(2f);
            manager.SpawnSquadFromLoadoutAt(loadout, manager.defaultSpawnPoint.position);
        }

        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }

    public void MarkUsed(SquadLoadout loadout)
    {
        if (loadout != null)
            usedLoadouts.Add(loadout);
        used = true;
    }
}

