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
    void Start()
    {
       // startOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        sprity = gameObject.GetComponentsInChildren<SpriteRenderer>();
        transformsy = new float[sprity.Length];
        for(int i=0; i < sprity.Length; i++)
        {
            if (sprity[i].transform.position.y>0)
            {
                transformsy[i] = sprity[i].transform.position.y - sprity[i].bounds.size.y / 2;
                sprity[i].sortingOrder = 1000 - Mathf.Abs((int)(100 * transformsy[i]));
                Debug.Log(sprity[i].bounds.size.y);
            }
            else
            {
                transformsy[i] = sprity[i].transform.position.y - sprity[i].bounds.size.y / 2;
                sprity[i].sortingOrder = 1000 + Mathf.Abs((int)(100 * transformsy[i]));
                Debug.Log(sprity[i].bounds.size.y);
            }
            
        }
    }

    
    void Update()
    {
        check();
    }

    public void check()
    {
        if(player.transform.position.y>0)
        {
            player.GetComponent<SpriteRenderer>().sortingOrder = 1000 - Mathf.Abs((int)(100 * player.transform.position.y) + (int)player.GetComponent<SpriteRenderer>().bounds.size.y / 2) ;
        }
        else
        {
            player.GetComponent<SpriteRenderer>().sortingOrder = 1000 + Mathf.Abs((int)(100 * player.transform.position.y) + (int)player.GetComponent<SpriteRenderer>().bounds.size.y / 2);
        }
        
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (collision.gameObject.layer == 3)
            {
                if (collision.transform.position.y > transform.position.y - heightDifferent)
                {
                    gameObject.GetComponent<SpriteRenderer>().sortingOrder = collision.GetComponentInParent<SpriteRenderer>().sortingOrder + 1;
                    Debug.Log("cipa");
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().sortingOrder = collision.GetComponentInParent<SpriteRenderer>().sortingOrder - 1;
                    Debug.Log("cipa2");
                }

            }

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(gameObject.layer == 6)
        {
            heightDifferent = 0;
        }
        else
        {
            heightDifferent= GetComponent<SpriteRenderer>().bounds.size.y / 2;
        }
        if (collision.gameObject.layer == 3)
        {
            if (collision.transform.position.y > transform.position.y - heightDifferent) 
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = collision.GetComponentInParent<SpriteRenderer>().sortingOrder  +1;
                Debug.Log("cipa");
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = collision.GetComponentInParent<SpriteRenderer>().sortingOrder - 1;
                Debug.Log("cipa2");
            }

        }
    }
  */
}
