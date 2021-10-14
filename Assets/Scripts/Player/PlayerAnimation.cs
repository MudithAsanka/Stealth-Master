using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private string IDLE = "Idle";
    private string RUN = "Run";
    
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    
    public void Run(bool run)
    {
        animator.SetBool(RUN, run);
    }

    public void Idle(bool idle)
    {
        animator.SetBool(IDLE, idle);
    }
}
