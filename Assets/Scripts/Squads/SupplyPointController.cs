using UnityEngine;
using System.Collections;

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

    private bool onCooldown;

    private void OnTriggerEnter(Collider other)
    {
        if (onCooldown)
            return;

        if (!other.CompareTag("Player"))
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
}

