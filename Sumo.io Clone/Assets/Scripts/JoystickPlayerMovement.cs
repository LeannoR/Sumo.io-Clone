using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerMovement : MonoBehaviour
{
    public FloatingJoystick floatingJoystick;
    public Rigidbody rb;

    public float speed;
    public Vector3 direction;
    public float yRotation;
    public void Start()
    {

    }
    public void FixedUpdate()
    {
        JoystickMovement();
    }
    public void Update()
    {
        LookYDirection();
    }

    public void JoystickMovement()
    {
        direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    public void LookYDirection()
    {
        transform.rotation = Quaternion.LookRotation(direction);
    }
}