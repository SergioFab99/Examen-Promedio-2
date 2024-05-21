using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject blackBulletPrefab;
    public GameObject whiteBulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFire;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire) // Clic izquierdo
        {
            nextFire = Time.time + fireRate;
            Shoot(whiteBulletPrefab);
        }
        else if (Input.GetMouseButton(1) && Time.time > nextFire) // Clic derecho
        {
            nextFire = Time.time + fireRate;
            Shoot(blackBulletPrefab);
        }
    }

    void Shoot(GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
