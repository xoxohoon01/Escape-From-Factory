using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTool : MonoBehaviour
{
    private Animator animator;
    private Camera camera;
    public float attackRate;
    private bool attacking;
    public float attackDistance;
    public float useStamina;
    public int damage;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        camera = Camera.main;
    }

    public void OnAttackInput()
    {
        if (!attacking)
        {
            attacking = true;
            animator.SetTrigger("attack");
            Invoke(nameof(OnCanAttack), attackRate);
        }
    }

    private void OnCanAttack()
    {
        attacking = false;
    }

    public void OnHit()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, attackDistance) && hit.collider.TryGetComponent(out EnemyCondition enemyCondition))
        {
            enemyCondition.TakePhysicalDamage(damage);
        }
    }
}
