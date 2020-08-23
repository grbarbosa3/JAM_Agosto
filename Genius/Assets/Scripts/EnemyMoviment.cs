using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private Transform posiInicial;
    [SerializeField] private Transform[] posiCores;
    [SerializeField] private float enemySpeed = 1;
    [SerializeField] private float jumpForce = 1;
    [SerializeField] private string GroundCheckName;
    [SerializeField] private int quantCoresAdd = 1;
    [SerializeField] private float distMin = 0.5f;
    private Rigidbody2D rb;
    private DetectedColor caughtColor;
    private List<int> listCores;
    private int aux = 0;
    private int aux2 = -1;
    private int coresAdd = 0;
    private int add;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        caughtColor = GetComponent<DetectedColor>();
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
    void FixedUpdate()
    {
        if (gm.whoPLay == 0 && IsGrounded())
        {
            if (aux < listCores.Count)
            {
                Vector2 vel = new Vector2(posiCores[listCores[aux]].position.x - transform.position.x, 0);
                if (IsGrounded())
                    rb.velocity = new Vector2 (vel.normalized.x * enemySpeed,rb.velocity.y);
                if (Mathf.Abs(posiCores[listCores[aux]].position.x - transform.position.x) <distMin)
                {
                    Pular();
                    aux++;
                }
            }
            else if (aux == listCores.Count && coresAdd < quantCoresAdd)
            {
                if (aux2!=aux)
                {
                    add = Random.Range(0,posiCores.Length);
                    aux2 = aux;
                }
                Vector2 vel = new Vector2(posiCores[add].position.x - transform.position.x, 0);
                if (IsGrounded())
                {
                    rb.velocity = new Vector2(vel.normalized.x * enemySpeed, rb.velocity.y);
                }
                if (Mathf.Abs(posiCores[add].position.x-transform.position.x)<distMin)
                {
                    if (caughtColor.GetColor() >= 0 && caughtColor.GetSprite() != null)
                        gm.AddCor(caughtColor.GetColor(), caughtColor.GetSprite());
                    Pular();
                    aux++;
                    coresAdd++;
                }
            }
        }
    }
    private void Update()
    {
        if (coresAdd == quantCoresAdd && IsGrounded())
        {
            coresAdd = 0;
            aux = 0;
            gm.whoPLay = 1;
            transform.position = posiInicial.position;
            rb.velocity = Vector2.zero;
        }
    }
}
