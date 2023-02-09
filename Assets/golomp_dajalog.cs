using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golomp_dajalog : MonoBehaviour
{
    List<string> list = new List<string>();
    public GameObject gracz;
    private bool jeden = true;
    // Start is called before the first frame update
    void Awake()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jeden)
        {
            
            if (collision.collider.gameObject == gracz)
            {
                gracz.GetComponent<playerMovement>().ruch = false;
                gracz.GetComponent<dialogi>().dziala = true;
                gracz.GetComponent<dialogi>().liczba = 0;
                for (int i = 0; i < list.Count-1; i++)
                {
                    gracz.GetComponent<dialogi>().tab[i] = list[i];
                }
                jeden = false;
            }
        }
        
    }
}
