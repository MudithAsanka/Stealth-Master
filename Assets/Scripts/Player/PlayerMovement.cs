using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    //private CharacterController charController;
    //private CollisionFlags collisionFlags = CollisionFlags.None;
    private Rigidbody rigidbody;

    private FloatingJoystick floatingJoystick;

    public float moveSpeed = 20f;
        
    // Awake is called the first
    void Awake()
    {
        animator = GetComponent<Animator>();
        //charController = GetComponent<CharacterController>();
        floatingJoystick = FindObjectOfType<FloatingJoystick>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Run();
    }

    void Run()
    {
        rigidbody.velocity = new Vector3(-floatingJoystick.Horizontal * moveSpeed, rigidbody.velocity.y, -floatingJoystick.Vertical * moveSpeed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(floatingJoystick.Direction), 15.0f * Time.deltaTime);

    }
    
} // end-class
