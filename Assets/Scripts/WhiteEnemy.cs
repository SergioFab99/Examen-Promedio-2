using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEnemy : Enemy
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WhiteBullet"))
        {
            TakeDamage(50);
        }
    }
}
