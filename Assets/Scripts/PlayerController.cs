using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    public float health = 100f;
    public GameObject blackBulletPrefab;
    public GameObject whiteBulletPrefab;
    public Transform blackShootPoint; // Cambiado de shootPoint a blackShootPoint
    public Transform whiteShootPoint; // Cambiado de shootPoint2 a whiteShootPoint
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime;

    void Update()
    {
        Move();
        Fire();
    }

    void Move()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Movimiento hacia adelante y hacia atrás en la dirección de la cámara
        if (moveVertical != 0)
        {
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0; // Ignorar la componente y para evitar moverse hacia arriba o abajo
            forward.Normalize();

            transform.position += forward * moveVertical * speed * Time.deltaTime;
        }

        // Rotación sobre su propio eje
        if (moveHorizontal != 0)
        {
            float rotation = moveHorizontal * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotation, 0);
        }
    }

    void Fire()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot(blackBulletPrefab, blackShootPoint);
        }
        else if (Input.GetMouseButton(1) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot(whiteBulletPrefab, whiteShootPoint);
        }
    }

    void Shoot(GameObject bulletPrefab, Transform shootPoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        // Asignar la dirección de la bala en función de la rotación del shootPoint
        if (bulletPrefab.GetComponent<BlackBullet>() != null)
        {
            bullet.GetComponent<BlackBullet>().Initialize(shootPoint.forward);
        }
        else if (bulletPrefab.GetComponent<WhiteBullet>() != null)
        {
            bullet.GetComponent<WhiteBullet>().Initialize(shootPoint.forward);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            // Manejar la muerte del jugador
            Destroy(gameObject);
        }
    }
}
