using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;
    void Update()
    {
        transform.position = player.position + offset;
        transform.LookAt(player);
    }
}
