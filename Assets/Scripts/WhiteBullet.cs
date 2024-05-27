using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    private Vector3 direction;

    public void Initialize(Vector3 shootDirection)
    {
        direction = shootDirection;
    }

    void Start()
    {
        // Destruir la bala después de un tiempo para evitar acumular objetos
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Mover la bala en la dirección del shootDirection
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        
    }
}
