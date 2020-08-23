using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacao : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GroundCheck gc;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gc = GetComponentInChildren<GroundCheck>();
    }
    private void Update()
    {
        anim.SetFloat("Speed", rb.velocity.normalized.sqrMagnitude);
        anim.SetBool("Jump", !gc.isGrounded);
    }
}
