using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    public NavMeshAgent agent { get; private set; }
    public LayerMask playerLayer;
    public Animator animator;
    public Transform Target;
    public float detectionRange = 6f;
    public float attackRange = 1f;

    private IAIState currentState;
    private float boxSize = 5f;
    private bool isHit;
    RaycastHit hit;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        currentState = new IdleState();
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(IAIState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    public bool CheckForPlayer()
    {
        Vector3 halfExtents = new Vector3(boxSize, boxSize, boxSize);
        Ray ray = new Ray(transform.position, transform.forward);
        isHit = Physics.BoxCast(ray.origin, halfExtents, ray.direction, out hit, Quaternion.identity, detectionRange, playerLayer);
        if (isHit)
        {
            //Target = hit.transform;
            Debug.Log("Player detected and set as target!");
            return true;
        }
        else
        {
            //Target = null;
        }
        return false;
    }

    public void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * detectionRange;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, detectionRange, NavMesh.AllAreas);
        agent.SetDestination(navHit.position);
    }

    public void PerformAttack()
    {
        // ���� ���� ����
        Debug.Log("Attacking the player!");
        animator.SetTrigger("attack");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 halfExtents = new Vector3(boxSize, boxSize, boxSize);
        Vector3 boxCenter;

        if (isHit)
        {
            // �浹�� ������ ��� �浹 ���������� ���̿� �ڽ� ǥ��
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance); // �浹 ���������� ����
            boxCenter = transform.position + transform.forward * hit.distance;     // �浹 ��ġ�� �ڽ� ǥ��
            Gizmos.DrawWireCube(boxCenter, halfExtents * 2);                      // �ڽ� ũ�� (��ü ũ��� ����)
        }
        else
        {
            // �浹�� ���� ��� �ִ� Ž�� �Ÿ������� ���̿� �ڽ� ǥ��
            Gizmos.DrawRay(transform.position, transform.forward * detectionRange);  // �ִ� Ž�� �Ÿ������� ����
            boxCenter = transform.position + transform.forward * detectionRange;     // �ִ� �Ÿ� ��ġ�� �ڽ� ǥ��
            Gizmos.DrawWireCube(boxCenter, halfExtents * 2);                      // �ڽ� ũ�� (��ü ũ��� ����)
        }
    }
}
