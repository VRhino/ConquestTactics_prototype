using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controls an individual unit in combat.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(UnitAIController))]
public class UnitController : MonoBehaviour
{
    public enum UnitState { Inactive, Active, InCombat }

    [HideInInspector] public Vector3 assignedFormationPosition;
    [HideInInspector] public bool isAlive = true;

    public NavMeshAgent agent { get; private set; }
    public UnitAIController ai { get; private set; }
    public HealthComponent health { get; private set; }

    private UnitState currentState = UnitState.Inactive;
    private bool formationMode = false;

    public delegate void UnitDeathHandler(UnitController unit);
    public event UnitDeathHandler OnDeath;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ai = GetComponent<UnitAIController>();
        health = GetComponent<HealthComponent>();

        if (health != null)
        {
            isAlive = health.IsAlive;
            health.OnDeath += HandleDeath;
        }
    }

    private void OnDestroy()
    {
        if (health != null)
        {
            health.OnDeath -= HandleDeath;
        }
    }

    private void Update()
    {
        if (formationMode && currentState == UnitState.Active)
        {
            agent.SetDestination(assignedFormationPosition);
        }
    }

    public void SetState(UnitState newState)
    {
        currentState = newState;
    }

    public void SetFormationMode(bool enable)
    {
        formationMode = enable;
    }

    public bool IsInFormationMode()
    {
        return formationMode;
    }

    public void ApplyDamage(int amount)
    {
        if (health != null)
        {
            health.ApplyDamage(amount);
        }
    }

    private void HandleDeath()
    {
        if (!isAlive)
            return;

        isAlive = false;
        if (agent != null)
        {
            agent.isStopped = true;
        }

        OnDeath?.Invoke(this);
    }
}
