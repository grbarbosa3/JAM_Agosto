using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectColor : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private Transform posiInicial;
    [SerializeField] private int quantCoresAdd = 1;
    [SerializeField] private int nextPlayer = 0;
    [SerializeField] private GameObject scorePanel;
    private int score = 0;
    private DetectedColor caughtColor;
    private CanWlak can;
    private PlayerJump jump;
    private List<int> listCores;
    private int aux = 0;
    private bool multiplayer;
    private bool lose = false;
    private bool press;
    private int coresAdd = 0;

    private void Awake()
    {
        multiplayer = gm.GetMultiplayer();
        caughtColor = GetComponent<DetectedColor>();
        can = GetComponent<CanWlak>();
        jump = GetComponent<PlayerJump>();
        listCores = gm.listaDecor;
    }
    private void FixedUpdate()
    {
        if (press)
        {
            if (can.GetPlayerN() == gm.whoPLay && jump.IsGrounded())
            {
                if (caughtColor.GetColor()>= 0 && caughtColor.GetSprite() != null)
                {
                    if(aux<listCores.Count)
                    {
                        if(caughtColor.GetColor() == listCores[aux])
                        {
                            aux++;
                            score++;
                            Debug.Log(aux);
                        }
                        else
                        {
                            lose=true;
                        }
                    }
                    if(aux == listCores.Count)
                    {
                        if (coresAdd < quantCoresAdd && jump.IsGrounded())
                        {
                            gm.AddCor(caughtColor.GetColor(), caughtColor.GetSprite());
                            aux++;
                            coresAdd++;
                            Debug.Log(aux);
                        }
                    }
                }
            }
        }
        if (lose)
        {
            if (multiplayer)
                Destroy(this.gameObject);
            else
            {
                Time.timeScale = 0f;
                scorePanel.SetActive(true);
            }
        }
    }
    private void Update()
    {
        press = Input.GetButtonDown("Jump");
        if (coresAdd == quantCoresAdd && jump.IsGrounded())
        {
            aux = 0;
            coresAdd = 0;
            gm.whoPLay = nextPlayer;
            transform.position = posiInicial.position;
        }
    }
}
