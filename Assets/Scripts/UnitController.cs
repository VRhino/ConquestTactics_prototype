using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controls an individual unit in combat.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(DefenseStats))]
[RequireComponent(typeof(UnitAIController))]
public class UnitController : MonoBehaviour
{
    /// <summary>
    /// Current active state of the unit. Inactive units do not move or run AI.
    /// </summary>
    public enum UnitState { Inactive, Active, InCombat }

    /// <summary>
    /// Position in world space that this unit should occupy when following a
    /// formation. Assigned by <see cref="FormationController"/>.
    /// </summary>
    [HideInInspector] public Vector3 assignedFormationPosition;

    /// <summary>
    /// Indicates whether the unit is still alive.
    /// </summary>
    [HideInInspector] public bool isAlive = true;

    public NavMeshAgent agent { get; private set; }
    public UnitAIController ai { get; private set; }
    public HealthComponent health { get; private set; }
    public DefenseStats defense { get; private set; }

    private UnitState currentState = UnitState.Inactive;
    private bool formationMode = false;

    public delegate void UnitDeathHandler(UnitController unit);
    public event UnitDeathHandler OnDeath;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ai = GetComponent<UnitAIController>();
        health = GetComponent<HealthComponent>();
        defense = GetComponent<DefenseStats>();

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

    /// <summary>
    /// Assigns the unit to a specific world position inside a formation and
    /// immediately sets the NavMeshAgent destination.
    /// Called by <see cref="FormationController"/>.
    /// </summary>
    /// <param name="worldPosition">Target position in world space.</param>
    public void AssignToFormation(Vector3 worldPosition)
    {
        assignedFormationPosition = worldPosition;
        formationMode = true;
        if (agent != null)
        {
            agent.SetDestination(worldPosition);
        }
    }

    /// <summary>
    /// Applies damage to the unit through its <see cref="HealthComponent"/>.
    /// If the component determines that the unit has died the <c>OnDeath</c>
    /// event will be triggered via <see cref="HandleDeath"/>.
    /// </summary>
    /// <param name="amount">Amount of damage to apply.</param>
    public void ApplyDamage(int amount)
    {
        if (health != null)
        {
            health.ApplyDamage(amount);
        }
    }

    /// <summary>
    /// Enables or disables the unit's movement and AI logic.
    /// When inactive the NavMeshAgent is stopped and the AI disabled.
    /// </summary>
    public void SetActive(bool active)
    {
        currentState = active ? UnitState.Active : UnitState.Inactive;

        if (agent != null)
        {
            agent.isStopped = !active;
        }

        if (ai != null)
        {
            ai.enabled = active;
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
