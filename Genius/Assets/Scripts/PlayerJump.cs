using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private string GroundCheckName;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Pular();
    }
    bool IsGrounded()
    {
        return transform.Find(GroundCheckName).GetComponent<GroundCheck>().isGrounded;
    }
    void Pular()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity += Vector2.up * jumpForce;
        }

    }
}
