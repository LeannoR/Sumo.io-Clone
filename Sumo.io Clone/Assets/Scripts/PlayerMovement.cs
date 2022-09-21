using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Vector3 direction;

    public FloatingJoystick joystick;
    public Vector3 lookDirection;
    public float movementSpeed = 10f;


    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void FixedUpdate()
    {
        Movement();
        LookRotation();
    }
    
    public void Movement()
    {
        direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        if(direction.magnitude > 0)
        {
            animator.SetBool("isRunning", true);
            lookDirection = direction;
        }
        transform.position = transform.position + lookDirection * movementSpeed * Time.fixedDeltaTime;
    }

    public void LookRotation()
    {
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
