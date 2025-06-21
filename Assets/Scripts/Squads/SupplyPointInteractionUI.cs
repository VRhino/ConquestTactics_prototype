using UnityEngine;

/// <summary>
/// Minimal placeholder UI controller for interacting with supply points.
/// </summary>
public class SupplyPointInteractionUI : MonoBehaviour
{
    public void ShowOptions(SupplyPointController point)
    {
        // Display UI - implementation can be extended.
        gameObject.SetActive(true);
    }
}
