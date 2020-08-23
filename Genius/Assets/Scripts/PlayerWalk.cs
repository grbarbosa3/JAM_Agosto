using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] private float vel = 1f;
    [SerializeField] private string ipt;
    private Rigidbody2D rb;
    private CanWlak can;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        can = GetComponent<CanWlak>();
    }
    private void FixedUpdate()
    {
        float aux = Input.GetAxis(ipt);
        if (can.GetCan())
        {
            if (aux > 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                rb.velocity = new Vector2(vel, rb.velocity.y);
            }
            else if (aux < 0)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
                rb.velocity = new Vector2(-vel, rb.velocity.y);
            }
            else
                rb.velocity = new Vector2(0, rb.velocity.y);
        }
       
    }
}
