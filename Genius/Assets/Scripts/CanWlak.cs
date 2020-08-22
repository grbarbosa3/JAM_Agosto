using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanWlak : MonoBehaviour
{
    [SerializeField] private Transform positionInicial;
    [SerializeField] private int playerN = 1;
    [SerializeField] private GameManager gm;
    private bool can = false;

    // Update is called once per frame
    void Update()
    {
        if(gm.whoPLay == playerN)
        {
            can = true;
        }
        else
        {
            can = false;
        }
    }
    public bool GetCan()
    {
        return can;
    }
}
