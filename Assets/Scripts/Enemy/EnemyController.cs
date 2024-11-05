using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    private EnemyCondition condition;
    private Animator animator;

    private Vector3 moveVector;

    public bool isMove { get; private set; }

    private float moveDelay = 0;
    private float moveSpan = 0;

    private float minMoveSpeed = 0.8f;
    private float maxMoveSpeed = 2.0f;

    private void CheckCanMove()
    {
        if (moveDelay > 0) moveDelay -= Time.deltaTime;
        if (moveSpan > 0) moveSpan -= Time.deltaTime;

        if (!isMove)
        {
            if (moveDelay <= 0)
            {
                transform.eulerAngles = new Vector3(0, UnityEngine.Random.Range(0.0f, 360.0f), 0);
                float _moveSpeed = UnityEngine.Random.Range(minMoveSpeed, maxMoveSpeed);
                moveVector = transform.forward * _moveSpeed;
                isMove = true;
                moveSpan = UnityEngine.Random.Range(2.0f, 4.0f);

                animator.SetFloat("speed", 1);
            }
        }
        else
        {
            if (moveSpan <= 0)
            {
                isMove = false;
                moveDelay = UnityEngine.Random.Range(2.0f, 5.0f);

                animator.SetFloat("speed", 0);
            }
                
        }
    }

    private void Move()
    {
        if (moveSpan > 0)
        {
            Vector3 _dir = new Vector3(moveVector.x, 0, moveVector.z).normalized * Time.deltaTime;
            rb.MovePosition(rb.position + _dir);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        moveDelay = UnityEngine.Random.Range(0.2f, 1.0f);
    }

    private void Update()
    {
        CheckCanMove();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + moveVector, 0.2f);
    }
}
