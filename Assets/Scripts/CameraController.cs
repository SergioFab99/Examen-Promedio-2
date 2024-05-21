using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(transform.position.x, player.position.y + 5, transform.position.z);
        }
    }
}
