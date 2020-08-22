using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedColor : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private int color = -1;
    private Sprite sprite = null;
    private Plataforma plat;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision!=null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            plat = collision.GetComponent<Plataforma>();
            if(plat!=null)
            {
                color = plat.GetCodPlat();
                sprite = plat.GetSprite();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            color = -1;
            sprite = null;
        }
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
    public int GetColor()
    {
        return color;
    }
}
