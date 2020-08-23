using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanWlak : MonoBehaviour
{
    [SerializeField] private Transform positionInicial;
    [SerializeField] private int playerN = 1;
    [SerializeField] private GameManager gm;
    private bool can = false;
    private Rigidbody2D rb;

    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if(gm.whoPLay == playerN)
        {
            can = true;
        }
        else
        {
            can = false;
            rb.velocity = Vector2.zero;
        }
    }
    public bool GetCan()
    {
        return can;
    }
    public int GetPlayerN()
    {
        return playerN;
    }
}
