using System;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Finite State Machine controller for tactical units.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CombatController))]
[RequireComponent(typeof(UnitController))]
public class UnitAIController : MonoBehaviour
{
    public enum AIState { Idle, MovingToFormation, FollowingLeader, EngagingEnemy, Attacking }

    [Header("AI Settings")]
    public float attackRange = 2f;
    public float formationReachThreshold = 1f;

    public EnemyDetectionSensor enemySensor;
    public Transform leader;

    private NavMeshAgent agent;
    private UnitController unit;
    private CombatController combat;
    private AIState currentState = AIState.Idle;
    private Transform currentEnemy;
    private bool followMode = true;

    public event Action<AIState> OnStateChanged;

    public AIState CurrentState => currentState;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        unit = GetComponent<UnitController>();
        combat = GetComponent<CombatController>();
        if (enemySensor == null)
            enemySensor = GetComponent<EnemyDetectionSensor>();
        if (enemySensor == null)
            enemySensor = gameObject.AddComponent<EnemyDetectionSensor>();

        var formation = GetComponentInParent<FormationController>();
        if (leader == null && formation != null)
            leader = formation.leaderTransform;
    }

    private void Update()
    {
        UpdateFSM();
    }

    /// <summary>
    /// Updates transitions and executes the current state logic.
    /// </summary>
    public void UpdateFSM()
    {
        EvaluateTransitions();
        ExecuteState();
    }

    private void EvaluateTransitions()
    {
        // Acquire enemies each frame
        if (enemySensor != null)
        {
            Transform detected = enemySensor.FindNearestEnemy();
            if (detected != null)
                currentEnemy = detected;
            else if (currentEnemy != null &&
                     Vector3.Distance(transform.position, currentEnemy.position) > enemySensor.detectionRadius)
                currentEnemy = null;
        }

        switch (currentState)
        {
            case AIState.Idle:
                if (currentEnemy != null)
                {
                    ChangeState(AIState.EngagingEnemy); // Enemy spotted
                }
                else if (followMode && leader != null)
                {
                    ChangeState(AIState.MovingToFormation); // Rejoin formation
                }
                break;

            case AIState.MovingToFormation:
                if (currentEnemy != null)
                {
                    ChangeState(AIState.EngagingEnemy); // Interrupt formation move
                }
                else if (!followMode)
                {
                    ChangeState(AIState.Idle); // Follow cancelled
                }
                else if (Vector3.Distance(transform.position, unit.assignedFormationPosition) <= formationReachThreshold)
                {
                    ChangeState(AIState.FollowingLeader); // Slot reached
                }
                break;

            case AIState.FollowingLeader:
                if (currentEnemy != null)
                {
                    ChangeState(AIState.EngagingEnemy); // Enemy near
                }
                else if (!followMode)
                {
                    ChangeState(AIState.Idle); // Stop following
                }
                break;

            case AIState.EngagingEnemy:
                if (currentEnemy == null)
                {
                    ChangeState(followMode ? AIState.MovingToFormation : AIState.Idle); // Lost target
                }
                else if (Vector3.Distance(transform.position, currentEnemy.position) <= attackRange)
                {
                    ChangeState(AIState.Attacking); // In range to attack
                }
                break;

            case AIState.Attacking:
                if (currentEnemy == null)
                {
                    ChangeState(followMode ? AIState.MovingToFormation : AIState.Idle); // Target gone
                }
                else if (Vector3.Distance(transform.position, currentEnemy.position) > attackRange)
                {
                    ChangeState(AIState.EngagingEnemy); // Target moved away
                }
                break;
        }
    }

    private void ExecuteState()
    {
        switch (currentState)
        {
            case AIState.Idle:
                agent.isStopped = true;
                break;
            case AIState.MovingToFormation:
            case AIState.FollowingLeader:
                agent.isStopped = false;
                agent.SetDestination(unit.assignedFormationPosition);
                break;
            case AIState.EngagingEnemy:
                agent.isStopped = false;
                if (currentEnemy != null)
                    agent.SetDestination(currentEnemy.position);
                break;
            case AIState.Attacking:
                agent.isStopped = true;
                if (currentEnemy != null &&
                    Vector3.Distance(transform.position, currentEnemy.position) <= attackRange)
                {
                    combat.TryAttack(currentEnemy.gameObject);
                }
                break;
        }
    }

    /// <summary>
    /// Allows external systems to force the current state.
    /// </summary>
    public void ForceState(AIState newState)
    {
        ChangeState(newState);
    }

    /// <summary>
    /// Enables or disables formation following.
    /// </summary>
    public void SetFollowMode(bool value)
    {
        followMode = value;
    }

    private void ChangeState(AIState newState)
    {
        if (currentState == newState)
            return;
        currentState = newState;
        OnStateChanged?.Invoke(currentState);
    }

    /// <summary>
    /// Sets a specific enemy as target and moves to engage it.
    /// </summary>
    public void SetTarget(Transform target)
    {
        if (target == null) return;
        currentEnemy = target;
        ChangeState(AIState.EngagingEnemy);
    }
}
