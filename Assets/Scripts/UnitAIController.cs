using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Finite State Machine based controller for individual units.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CombatController))]
public class UnitAIController : MonoBehaviour
{
    public enum AIState { Idle, FollowLeader, EngageEnemy, Attack }

    [Header("AI Settings")]
    public float followDistance = 5f;
    public float detectionRadius = 8f;
    public float attackRange = 2f;
    public LayerMask enemyLayers = ~0;

    private NavMeshAgent agent;
    private UnitController unit;
    private CombatController combat;
    private FormationController formation;

    public Transform leader;
    private AIState currentState = AIState.Idle;
    private Transform currentEnemy;
    private bool holdPosition;
    private Vector3 holdPoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        unit = GetComponent<UnitController>();
        combat = GetComponent<CombatController>();
        formation = GetComponentInParent<FormationController>();
        if (leader == null && formation != null)
            leader = formation.leaderTransform;
    }

    private void Update()
    {
        EvaluateTransitions();
        ExecuteState();
    }

    private void EvaluateTransitions()
    {
        if (holdPosition)
        {
            currentState = AIState.Idle;
            return;
        }

        DetectEnemies();

        switch (currentState)
        {
            case AIState.Idle:
                if (currentEnemy != null)
                    currentState = AIState.EngageEnemy;
                else if (leader != null && Vector3.Distance(transform.position, leader.position) > followDistance)
                    currentState = AIState.FollowLeader;
                break;

            case AIState.FollowLeader:
                if (currentEnemy != null)
                    currentState = AIState.EngageEnemy;
                else if (leader != null && Vector3.Distance(transform.position, leader.position) <= followDistance)
                    currentState = AIState.Idle;
                break;

            case AIState.EngageEnemy:
                if (currentEnemy == null)
                    currentState = leader != null ? AIState.FollowLeader : AIState.Idle;
                else if (Vector3.Distance(transform.position, currentEnemy.position) <= attackRange)
                    currentState = AIState.Attack;
                break;

            case AIState.Attack:
                if (currentEnemy == null)
                    currentState = leader != null ? AIState.FollowLeader : AIState.Idle;
                else if (Vector3.Distance(transform.position, currentEnemy.position) > attackRange)
                    currentState = AIState.EngageEnemy;
                break;
        }
    }

    private void ExecuteState()
    {
        switch (currentState)
        {
            case AIState.Idle:
                agent.isStopped = true;
                if (holdPosition)
                    agent.SetDestination(holdPoint);
                break;
            case AIState.FollowLeader:
                agent.isStopped = false;
                if (leader != null)
                    agent.SetDestination(leader.position);
                break;
            case AIState.EngageEnemy:
                agent.isStopped = false;
                if (currentEnemy != null)
                    agent.SetDestination(currentEnemy.position);
                break;
            case AIState.Attack:
                agent.isStopped = true;
                if (currentEnemy != null && combat != null)
                    combat.TryAttack(currentEnemy.gameObject);
                break;
        }
    }

    private void DetectEnemies()
    {
        if (currentEnemy != null)
        {
            HealthComponent hp = currentEnemy.GetComponent<HealthComponent>();
            if (hp == null || !hp.IsAlive || Vector3.Distance(transform.position, currentEnemy.position) > detectionRadius)
                currentEnemy = null;
        }

        if (currentEnemy == null)
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayers);
            foreach (var c in cols)
            {
                if (c.transform == transform) continue;
                var hp = c.GetComponent<HealthComponent>();
                if (hp != null && hp.IsAlive)
                {
                    currentEnemy = c.transform;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Allows external systems to force a state change.
    /// </summary>
    public void SetState(AIState newState) => currentState = newState;

    /// <summary>
    /// Orders the unit to hold its current position.
    /// </summary>
    public void SetToHoldPosition()
    {
        holdPosition = true;
        holdPoint = transform.position;
        currentEnemy = null;
        currentState = AIState.Idle;
    }

    /// <summary>
    /// Sets an enemy target for the unit.
    /// </summary>
    public void SetTarget(Transform target)
    {
        if (target == null) return;
        holdPosition = false;
        currentEnemy = target;
        currentState = AIState.EngageEnemy;
    }
}
