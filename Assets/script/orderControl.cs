using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class orderControl : MonoBehaviour
{
    public int startOrder;
    public SpriteRenderer[] sprity;
    public GameObject player;
    public float[] transformsy;
    public float heightDifferent;
    public Sprite mapa;
    void Start()
    {
       
        sprity = gameObject.GetComponentsInChildren<SpriteRenderer>();
        transformsy = new float[sprity.Length];
        for(int i=0; i < sprity.Length; i++)
        {
            
            transformsy[i] = 100*mapa.bounds.size.y / 2 - 100 *(sprity[i].transform.position.y - sprity[i].bounds.size.y/2) ;
            sprity[i].sortingOrder = (int)transformsy[i];
        }
    }

    
    void Update()
    {
        check();
    }

    public void check()
    {
        player.GetComponent<SpriteRenderer>().sortingOrder = (int)(100*(mapa.bounds.size.y / 2) - 100*player.transform.position.y);


    }
    
}
