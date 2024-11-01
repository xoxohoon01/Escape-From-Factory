using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public Animator animator { get; private set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
