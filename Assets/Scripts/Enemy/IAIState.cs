using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public interface IAIState
{
    void EnterState(EnemyAIController aiController);
    void UpdateState(EnemyAIController aiController);
    void ExitState(EnemyAIController aiController);
}


public class IdleState : IAIState
{
    private float idleDuration = 3f;
    private float idleTimer;

    public void EnterState(EnemyAIController aiController)
    {
        aiController.agent.isStopped = true;
        aiController.animator.SetFloat("speed", 0);
        aiController.animator.speed = 1;
        idleTimer = 0f;
    }

    public void UpdateState(EnemyAIController aiController)
    {
        idleTimer += Time.deltaTime;
        if (idleTimer >= idleDuration)
        {
            aiController.SwitchState(new WalkingState());
        }

        if (aiController.CheckForPlayer())
        {
            aiController.SwitchState(new AttackingState());
        }
    }

    public void ExitState(EnemyAIController aiController)
    {
        aiController.agent.isStopped = false;
    }
}


public class WalkingState : IAIState
{
    private float walkDuration = 5f;
    private float walkTimer;

    public void EnterState(EnemyAIController aiController)
    {
        aiController.SetRandomDestination();
        aiController.agent.speed = 1;
        aiController.animator.SetFloat("speed", 1);
        aiController.animator.speed = 1;
    }

    public void UpdateState(EnemyAIController aiController)
    {
        walkTimer += Time.deltaTime;

        if (!aiController.agent.pathPending && aiController.agent.remainingDistance < 0.5f || walkTimer >= walkDuration)
        {
            aiController.SwitchState(new IdleState());
        }

        if (aiController.CheckForPlayer())
        {
            aiController.SwitchState(new AttackingState());
        }
    }

    public void ExitState(EnemyAIController aiController)
    {

    }
}


public class AttackingState : IAIState
{
    public void EnterState(EnemyAIController aiController)
    {
        aiController.agent.isStopped = false;
        aiController.agent.speed = 2;
        aiController.SetRandomDestination();
        aiController.animator.SetFloat("speed", 2);
        aiController.animator.speed = 2;
    }

    public void UpdateState(EnemyAIController aiController)
    {
        Debug.Log(aiController.CheckForPlayer());
        if (!aiController.CheckForPlayer())
        {
            aiController.SwitchState(new IdleState());
            return;
        }

        aiController.agent.SetDestination(aiController.Target.position);

        float distanceToPlayer = Vector3.Distance(aiController.transform.position, aiController.Target.position);

        if (distanceToPlayer <= aiController.attackRange)
        {
            aiController.PerformAttack();
        }
        //else if (distanceToPlayer > aiController.detectionRange) 
        //{
        //    aiController.SwitchState(new IdleState());
        //}
    }

    public void ExitState(EnemyAIController aiController)
    {

    }
}