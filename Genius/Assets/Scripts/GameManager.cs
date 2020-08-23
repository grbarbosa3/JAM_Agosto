using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<int> listaDecor = new List<int>();
    public List<Sprite> listaDeSpritesDasCores = new List<Sprite>();
    public int whoPLay = 0;
    private int score = 0;
    [SerializeField] private bool multiplayer = false;
    private void Start()
    {
        if(multiplayer)
        {
            whoPLay=1;
        }
    }

    public void AddCor(int numCor,Sprite sCor)
    {
        listaDecor.Add(numCor);
        listaDeSpritesDasCores.Add(sCor);
    }
    public bool GetMultiplayer()
    {
        return multiplayer;
    }
    public void ScoreUp()
    {
        score++;
    }
}
