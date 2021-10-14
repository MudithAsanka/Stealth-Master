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
    public float joystickThreshold = 0.4f;
        
    // Awake is called the first
    void Awake()
    {
        animator = GetComponent<Animator>();
        //charController = GetComponent<CharacterController>();
        floatingJoystick = FindObjectOfType<FloatingJoystick>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        float h = floatingJoystick.Horizontal;
        float v = floatingJoystick.Vertical;
        Movement(h, v);
        
    }

    void Movement(float h, float v)
    {
        // begin - Player Rotation
        Vector3 targetDirection = new Vector3(-h, 0f, -v);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation,15f * Time.deltaTime);
        rigidbody.MoveRotation(newRotation);
        // end - Player Rotation
        
        // begin - Animate slowly idle to run
        if (floatingJoystick.Horizontal >= joystickThreshold || floatingJoystick.Vertical >= joystickThreshold || floatingJoystick.Horizontal <= -joystickThreshold || floatingJoystick.Vertical <= -joystickThreshold)
        {
            animator.SetBool("Run",true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        // end - Animate slowly idle to run
        
        // begin - Player velocity
        rigidbody.velocity = new Vector3(-h * moveSpeed, rigidbody.velocity.y, -v * moveSpeed);
        // end - Player Velocity
    }

} // end-class
