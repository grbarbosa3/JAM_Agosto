using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectColor : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private Transform posiInicial;
    [SerializeField] private int quantCoresAdd = 1;
    [SerializeField] private int nextPlayer = 0;
    private int score = 0;
    private DetectedColor caughtColor;
    private CanWlak can;
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
        listCores = gm.listaDecor;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (can.GetPlayerN() == gm.whoPLay)
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
    }
}
