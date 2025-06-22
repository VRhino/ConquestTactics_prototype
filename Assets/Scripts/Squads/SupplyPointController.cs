using System.Collections;
using UnityEngine;

/// <summary>
/// Handles player interaction with a tactical map supply point. When the player
/// enters the trigger zone and presses the configured key, a UI is shown to
/// allow swapping the current squad. Each point can be used only once per
/// battle.
/// </summary>
public class SupplyPointController : MonoBehaviour
{
    [Header("References")]
    [Tooltip("UI displayed when interacting with the supply point")]
    public SupplyPointInteractionUI interactionUI;

    [Tooltip("Optional hint object shown when the player can interact")]
    public GameObject interactHint;

    [Tooltip("Renderer used to change colour once consumed")]
    public Renderer pointRenderer;
    public Color usedColor = Color.gray;

    [Tooltip("Spawn location for the new squad. Defaults to this transform")] 
    public Transform spawnPosition;

    [Header("Settings")]
    public float despawnDelay = 1f;
    public KeyCode interactionKey = KeyCode.E;

    [HideInInspector] public bool isUsed = false;
    [HideInInspector] public bool canInteract = false;

    private Color originalColor;

    private void Awake()
    {
        if (pointRenderer != null)
            originalColor = pointRenderer.material.color;
        UpdateVisualState();
    }

    private void Update()
    {
        if (canInteract && !isUsed && Input.GetKeyDown(interactionKey))
        {
            ActivateSupplyPoint();
        }
    }

    /// <summary>
    /// Triggered when something enters the interaction area.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (isUsed)
            return;

        if (other.CompareTag("Player") || other.GetComponent<HeroInputController>() != null)
        {
            canInteract = true;
            if (interactHint != null)
                interactHint.SetActive(true);
        }
    }

    /// <summary>
    /// Triggered when something leaves the interaction area.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponent<HeroInputController>() != null)
        {
            canInteract = false;
            if (interactHint != null)
                interactHint.SetActive(false);
            if (interactionUI != null)
                interactionUI.Hide();
        }
    }

    /// <summary>
    /// Opens the squad selection UI if the point has not been used yet.
    /// </summary>
    public void ActivateSupplyPoint()
    {
        if (isUsed || interactionUI == null)
            return;

        Debug.Log("SupplyPoint activado");
        interactionUI.ShowOptions(this);
    }

    /// <summary>
    /// Called by the UI when the player confirms a new squad.
    /// </summary>
    public void ConfirmSquadChange(SquadLoadout loadout)
    {
        if (isUsed || loadout == null)
            return;

        StartCoroutine(ChangeSquadRoutine(loadout));
    }

    private IEnumerator ChangeSquadRoutine(SquadLoadout loadout)
    {
        var manager = SquadManager.Instance;
        if (manager != null)
        {
            manager.DeactivateCurrentSquad(despawnDelay);
            yield return new WaitForSeconds(despawnDelay);
            Vector3 pos = spawnPosition != null ? spawnPosition.position : transform.position;
            manager.SpawnSquadFromLoadoutAt(loadout, pos);
        }

        isUsed = true;
        canInteract = false;
        UpdateVisualState();

        Debug.Log("Escuadra reemplazada");
    }

    private void UpdateVisualState()
    {
        if (pointRenderer != null)
        {
            pointRenderer.material.color = isUsed ? usedColor : originalColor;
        }

        if (interactHint != null)
            interactHint.SetActive(canInteract && !isUsed);
    }

    // Compatibility method so existing controllers can still call Interact().
    public void Interact()
    {
        if (canInteract && !isUsed)
            ActivateSupplyPoint();
    }
}

