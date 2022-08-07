using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public int speed { get; set; }
    public bool shoot { get; set; }
    public bool walk { get; set; }
    public bool ground { get; set; }
    public bool crouch { get; set; }
    public bool jump { get; set; }

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetInteger("Speed", Mathf.Abs(speed));
        animator.SetBool("Shoot", shoot);
        animator.SetBool("Ground", ground);
        animator.SetBool("Crouch", crouch);
        animator.SetBool("Jump", jump);
    }
    public void GetHurt()
    {
        animator.SetBool("Hurt", true);
        animator.SetInteger("Speed", 0);
        animator.SetBool("Shoot", false);
        animator.SetBool("Ground", true);
        animator.SetBool("Crouch", false);
        animator.SetBool("Jump", false);
    }

    public void EndHurtAnimation()
    {
        animator.SetBool("Hurt", false);
    }
}
