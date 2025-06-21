using UnityEngine;

/// <summary>
/// Detects nearby enemies using OverlapSphere and returns the closest one.
/// </summary>
public class EnemyDetectionSensor : MonoBehaviour
{
    [Tooltip("Radius used to search for enemies")] public float detectionRadius = 8f;
    [Tooltip("Layer mask used during detection")] public LayerMask detectionLayers = ~0;
    [Tooltip("Tag used to identify enemy objects")] public string enemyTag = "Enemy";

    /// <summary>
    /// Finds the nearest enemy within the configured radius.
    /// </summary>
    /// <returns>Transform of the closest enemy or null if none found.</returns>
    public Transform FindNearestEnemy()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayers);
        Transform closest = null;
        float sqrMin = float.MaxValue;
        foreach (var hit in hits)
        {
            if (!hit.CompareTag(enemyTag))
                continue;

            float sqr = (hit.transform.position - transform.position).sqrMagnitude;
            if (sqr < sqrMin)
            {
                sqrMin = sqr;
                closest = hit.transform;
            }
        }
        return closest;
    }
}
