using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackRangeScript : MonoBehaviour
{
    public EquipTool weapon;
    List<Collider> colliders = new List<Collider>();
    private void OnEnable()
    {
        colliders.Clear();
    }
    private void OnTriggerStay(Collider collider)
    {
        if (!colliders.Contains(collider))
        {
            colliders.Add(collider);
            if (collider.GetComponent<IDamagable>() != null && weapon != null)
            {
                collider.GetComponent<IDamagable>().TakePhysicalDamage(weapon.damage);
            }
        }
    }

}
