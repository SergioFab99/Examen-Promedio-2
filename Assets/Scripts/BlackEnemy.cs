using UnityEngine;

public class BlackEnemy : Enemy
{
    protected override void MoveTowardsPlayer()
    {
        base.MoveTowardsPlayer();
    }
    //si colisiona con un obejto que tenga la etiqueta "Bullet" se destruye
   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlackBullet"))
        {
            // Manejar la colisión con el enemigo
            Destroy(gameObject);
            FindObjectOfType<EnemySpawner>().EnemyDestroyed();
        }
    }
}
