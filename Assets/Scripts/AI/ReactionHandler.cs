using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Detects when the unit is flanked and notifies via event.
/// </summary>
public class ReactionHandler : MonoBehaviour
{
    [Tooltip("Optional formation controller to request formation changes")] public FormationController formation;
    [Tooltip("Automatically react to flank events")] public bool autoReactToFlank = true;
    public UnityEvent OnFlanked;

    /// <summary>
    /// Call this when an attacker hits the unit to evaluate flank angle.
    /// </summary>
    /// <param name="attacker">Transform of the attacker.</param>
    public void EvaluateFlank(Transform attacker)
    {
        if (!autoReactToFlank || attacker == null) return;

        Vector3 dir = attacker.position - transform.position;
        float angle = Vector3.Angle(transform.forward, dir);
        if (angle > 120f)
        {
            OnFlanked?.Invoke();
            // Suggest switching formation if possible
            if (formation != null)
                formation.SendMessage("RequestAutoChange", "Círculo", SendMessageOptions.DontRequireReceiver);
        }
    }
}
