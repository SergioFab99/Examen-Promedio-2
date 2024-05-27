using UnityEngine;

public class WhiteEnemy : Enemy
{
    protected override void MoveTowardsPlayer()
    {
        base.MoveTowardsPlayer();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WhiteBullet"))
        {
            // Manejar la colisión con el enemigo
            Destroy(gameObject);
            FindObjectOfType<EnemySpawner>().EnemyDestroyed();
        }
    }
}
