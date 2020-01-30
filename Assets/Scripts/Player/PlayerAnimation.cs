using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Animator swordAnimation;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        swordAnimation = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
   public void Move(float move)
    {
        animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        animator.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
       
        swordAnimation.SetTrigger("SwordAnimation");

    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }
}
