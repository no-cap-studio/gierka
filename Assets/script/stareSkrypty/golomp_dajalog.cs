using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golomp_dajalog : MonoBehaviour
{
    public List<string> list = new List<string>();
    public GameObject gracz;
    public bool jeden = true;
    public int umaga = 0;
    // Start is called before the first frame update
    void Awake()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D colli)
    {
        
        if (jeden)
        {
            
            if (colli.gameObject == gracz)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    gracz.GetComponent<playerMovement>().ruch = false;
                    gracz.GetComponent<dialogi>().dziala = true;
                    gracz.GetComponent<dialogi>().tab = list;
                    gracz.GetComponent<dialogi>().napis.text = list[0];
                    jeden = false;
                }
                
                
            }
            
        }
        
    }
}
