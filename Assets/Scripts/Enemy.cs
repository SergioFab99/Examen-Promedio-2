using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Transform player;
    public float speed = 2f;
    public float health = 100f;  // Añadir una variable para la salud del enemigo

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        MoveTowardsPlayer();
    }

    protected virtual void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    public void TakeDamage(float amount)
    {
        // Reducir la salud del enemigo
        health -= amount;

        // Si la salud del enemigo llega a cero, destruir el enemigo
        if (health <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<EnemySpawner>().EnemyDestroyed();
        }
    }
}
