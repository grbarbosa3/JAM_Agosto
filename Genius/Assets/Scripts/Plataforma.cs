using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private int codPlat = 0;

    public Sprite GetSprite()
    {
        return sprite;
    }
    public int GetCodPlat()
    {
        return codPlat;
    }
}
