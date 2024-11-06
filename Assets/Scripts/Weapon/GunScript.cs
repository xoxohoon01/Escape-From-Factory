using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform flashPoint;

    private float fireRate = 3.5f;
    private float fireDelay;

    public void Fire()
    {
        if (Input.GetMouseButton(0))
        {
            if (fireDelay <= 0)
            {
                GameObject newBullet = Instantiate(bullet);
                newBullet.transform.position = flashPoint.position;
                newBullet.transform.eulerAngles = transform.forward;
                newBullet.GetComponent<BulletScript>().Launch(10f);
                fireDelay = 1 / fireRate;
            }
        }
    }

    private void Update()
    {
        if (fireDelay > 0)
            fireDelay -= Time.deltaTime;

        Fire();
    }
}
