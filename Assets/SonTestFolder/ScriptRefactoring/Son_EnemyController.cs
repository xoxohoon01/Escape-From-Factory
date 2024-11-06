using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public enum AIState
{
    Idle,
    Wandering,
    Attacking
}

public class Son_EnemyController : MonoBehaviour
{
    private Animator animator;

    [Header("Stats")]
    public float walkSpeed;
    public float runSpeed;
    //public ItemData[] dropOnDeath;

    [Header("AI")]
    private NavMeshAgent agent;
    public float detectDistance;
    private AIState aiState;

    [Header("Wandering")]
    public float minWanderDistance;
    public float maxWanderDistance;
    public float minWanderWaitTime;
    public float maxWanderWaitTime;

    [Header("Combat")]
    public int damage;
    public float attackRate;
    private float lastAttackTime;
    public float attackDistance;

    private float playerDistance;
    public float fieldOfView = 120f;




    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetState(AIState.Wandering);
    }

    private void Update()
    {
        UpdateState(aiState);
    }
    private void SetState(AIState state)
    {
        aiState = state;

        switch (aiState)
        {
            case AIState.Idle:
                agent.speed = walkSpeed;
                agent.isStopped = true;
                break;
            case AIState.Wandering:
                agent.speed = walkSpeed;
                agent.isStopped = false;
                break;
            case AIState.Attacking:
                agent.speed = runSpeed;
                agent.isStopped = false;
                break;
        }
        animator.speed = agent.speed / walkSpeed;
    }

    private void UpdateState(AIState state)
    {
        switch (aiState)
        {
            case AIState.Idle:
            case AIState.Wandering:
                PassiveUpdate();
                break;
            case AIState.Attacking:
                AttackingUpdate();
                break;
        }
    }

    private void PassiveUpdate()
    {

    }

    private void AttackingUpdate()
    {

    }

}
