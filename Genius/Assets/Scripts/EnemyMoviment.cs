using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private Transform[] posiCores;
    [SerializeField] private float enemySpeed = 1;
    [SerializeField] private float jumpForce = 1;
    [SerializeField] private string GroundCheckName;
    private Rigidbody2D rb;
    private List<int> listCores;
    private int aux = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        listCores = gm.listaDecor;
    }
    // Update is called once per frame
    bool IsGrounded()
    {
        return transform.Find(GroundCheckName).GetComponent<GroundCheck>().isGrounded;
    }
    void Pular()
    {
        if (IsGrounded())
        {
            rb.velocity = Vector2.up * jumpForce;
        }

    }
    void Update()
    {
        if (aux < listCores.Count)
        {
            Vector2 vel = posiCores[aux].position - transform.position;
            if(IsGrounded())
                rb.velocity = new Vector2 (vel.normalized.x * enemySpeed,0);
            //if()
        }
    }

}
