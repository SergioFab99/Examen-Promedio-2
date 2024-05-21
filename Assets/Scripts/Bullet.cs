using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 50;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.CompareTag("Enemy"))
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                if ((gameObject.CompareTag("BlackBullet") && hitInfo.GetComponent<BlackEnemy>()) ||
                    (gameObject.CompareTag("WhiteBullet") && hitInfo.GetComponent<WhiteEnemy>()))
                {
                    enemy.TakeDamage(damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}