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

    private Transform currentTarget;
    private bool holdPosition;
    private Vector3 holdPoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        unit = GetComponent<UnitController>();
    }

    private void Update()
    {
        if (unit == null || agent == null)
            return;

        if (unit.IsInFormationMode())
        {
            agent.SetDestination(unit.assignedFormationPosition);
        }
        else if (holdPosition)
        {
            agent.SetDestination(holdPoint);
        }
        else if (currentTarget != null)
        {
            agent.SetDestination(currentTarget.position);
        }
    }

    /// <summary>
    /// Orders the unit to hold its current position.
    /// </summary>
    public void SetToHoldPosition()
    {
        holdPosition = true;
        currentTarget = null;
        holdPoint = transform.position;
        if (agent != null)
            agent.SetDestination(holdPoint);
    }

    /// <summary>
    /// Sets an attack or movement target for the unit.
    /// </summary>
    public void SetTarget(Transform target)
    {
        if (target == null)
            return;

        currentTarget = target;
        holdPosition = false;
        agent.SetDestination(target.position);
    }
}
