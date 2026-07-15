using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    PlayerController controller;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        anim.SetBool("IsRun", rb.linearVelocity.x != 0);
        anim.SetBool("IsGround", controller.isGround);
        anim.SetFloat("YVelocity", rb.linearVelocity.y);
    }

}
