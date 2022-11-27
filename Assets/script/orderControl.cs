using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class orderControl : MonoBehaviour
{
    public float maxRadius;
    public Collider2D[] overlaps = new Collider2D[50];
    public GameObject player;
    public Vector3 spriteSize;
    void Start()
    {
        
    }

    
    void Update()
    {
        check();
    }

    public void check()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, maxRadius, overlaps);
        for(int i =0; i<overlaps.Length - 1; i++)
        {
            spriteSize = new Vector3(overlaps[i].GetComponent<SpriteRenderer>().bounds.size.x, overlaps[i].GetComponent<SpriteRenderer>().bounds.size.y, 0.1);
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform.position.y + overlaps[i].GetComponent<BoxCollider2D>().offset.y > transform.position.y + gameObject.GetComponent<BoxCollider2D>().offset.y )
                {
                    player.GetComponent<SpriteRenderer>().sortingOrder = overlaps[i].GetComponent<SpriteRenderer>().sortingOrder + 1;
                }
                else
                {
                    player.GetComponent<SpriteRenderer>().sortingOrder = overlaps[i].GetComponent<SpriteRenderer>().sortingOrder - 1;
                }
            }
            
        }
            
        
    }
}
