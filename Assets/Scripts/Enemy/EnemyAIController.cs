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

    public GameObject testCube;

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

    // 상태 전환
    public void SwitchState(IAIState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    // 상태 판단
    public bool CheckForPlayer()
    {
        Vector3 halfExtents = new Vector3(boxSize, boxSize, boxSize);
        Collider[] colliders = Physics.OverlapBox(transform.position + (transform.forward * detectionRange), halfExtents, Quaternion.identity, playerLayer);

        if (colliders.Length > 0)
        {
            Target = colliders[0].transform;
            return true;
        }
        return false;

        /*
        isHit = Physics.BoxCast(ray.origin, halfExtents, ray.direction, out hit, Quaternion.identity, detectionRange, playerLayer);
        if (isHit)
        {

            testCube.transform.position = hit.transform.position;
            //Target = hit.transform;
            Debug.Log("Player detected and set as target!");
            return true;
        }
        else
        {
            //Target = null;
        }
        return false;
        */
    }

    // 행동 (이동)
    public void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * detectionRange;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, detectionRange, NavMesh.AllAreas);
        agent.SetDestination(navHit.position);
    }

    // 행동 (공격)
    public void PerformAttack()
    {
        // 공격 실행 로직
        Debug.Log("Attacking the player!");
        animator.SetTrigger("attack");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 halfExtents = new Vector3(boxSize, boxSize, boxSize);
        Vector3 boxCenter;

        Gizmos.DrawRay(transform.position, transform.forward * detectionRange);
        Gizmos.DrawWireCube(transform.position + (transform.forward * detectionRange), halfExtents * 2);

        /*
        if (isHit)
        {
            // 충돌이 감지된 경우 충돌 지점까지의 레이와 박스 표시
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance); // 충돌 지점까지의 레이
            boxCenter = transform.position + transform.forward * hit.distance;     // 충돌 위치에 박스 표시
            Gizmos.DrawWireCube(boxCenter, halfExtents * 2);                      // 박스 크기 (전체 크기로 설정)
        }
        else
        {
            // 충돌이 없을 경우 최대 탐지 거리까지의 레이와 박스 표시
            Gizmos.DrawRay(transform.position, transform.forward * detectionRange);  // 최대 탐지 거리까지의 레이
            boxCenter = transform.position + transform.forward * detectionRange;     // 최대 거리 위치에 박스 표시
            Gizmos.DrawWireCube(boxCenter, halfExtents * 2);                      // 박스 크기 (전체 크기로 설정)
        }
        */
    }
}
