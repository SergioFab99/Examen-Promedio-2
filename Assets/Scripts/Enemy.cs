using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    public int health = 100;
    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (rb == null)
        {
            Debug.LogError("Rigidbody no encontrado en el enemigo.");
        }
        if (player == null)
        {
            Debug.LogError("No se encontró al jugador.");
        }

        // Asegurarse de que la gravedad esté desactivada
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
