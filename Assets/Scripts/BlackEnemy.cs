using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemy : Enemy
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BlackBullet"))
        {
            TakeDamage(50);
        }
    }
}