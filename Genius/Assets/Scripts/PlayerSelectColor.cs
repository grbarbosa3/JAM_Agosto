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
    private int coresAdd = 0;
    private int cor;
    private Sprite sprite;

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
        if (Input.GetButtonDown("Jump"))
        {
            if (can.GetPlayerN() == gm.whoPLay && jump.IsGrounded())
            {
                cor = caughtColor.GetColor();
                sprite = caughtColor.GetSprite();
                if (cor>=0 && sprite != null)
                {
                    if(aux<listCores.Count)
                    {
                        if(cor == listCores[aux])
                        {
                            aux++;
                            score++;
                        }
                        else
                        {
                            lose=true;
                        }
                    }
                    if(aux == listCores.Count)
                    {
                        if (coresAdd < quantCoresAdd)
                        {
                            gm.AddCor(cor, sprite);
                            aux++;
                            coresAdd++;
                        }
                        if(coresAdd==quantCoresAdd)
                        {
                            aux = 0;
                            coresAdd = 0;
                            gm.whoPLay = nextPlayer;
                            transform.position = posiInicial.position;
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
}
