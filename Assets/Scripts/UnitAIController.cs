using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Placeholder AI controller for units.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class UnitAIController : MonoBehaviour
{
    private NavMeshAgent agent;
    private UnitController unit;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        unit = GetComponent<UnitController>();
    }

    private void Update()
    {
        // Basic follow behavior in formation
        if (unit != null && unit.agent != null && unit.IsInFormationMode())
        {
            agent.SetDestination(unit.assignedFormationPosition);
        }
    }
}
