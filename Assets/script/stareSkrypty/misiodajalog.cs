using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misiodajalog : MonoBehaviour
{
    public List<string> list = new List<string>();
    public GameObject gracz;
    private bool jedenen = true;
    private bool dwa = false;
    public GameObject golomp;
    private bool pierwszy = true;
    public GameObject licznik;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pierwszy = golomp.GetComponent<golomp_dajalog>().jeden; 
    }
    private void OnTriggerStay2D(Collider2D colli)
    {
        if (!pierwszy && jedenen)
        {

            if (colli.gameObject == gracz && Input.GetKeyDown(KeyCode.E))
            {
                gracz.GetComponent<playerMovement>().ruch = false;
                gracz.GetComponent<dialogi>().dziala = true;
                gracz.GetComponent<dialogi>().tab = list;
                gracz.GetComponent<dialogi>().napis.text = list[0];
                jedenen = false;
                licznik.SetActive(true);
            }
        }
        else if (pierwszy)
        {
            if (colli.gameObject == gracz && Input.GetKeyDown(KeyCode.E))
            {
                gracz.GetComponent<dialogi>().tab.Clear();
                gracz.GetComponent<playerMovement>().ruch = false;
                gracz.GetComponent<dialogi>().dziala = true;
                gracz.GetComponent<dialogi>().liczba = 0;
                gracz.GetComponent<dialogi>().napis.text = "Wracaj gadaæ z gruchaj³o";
            }
        }
    }
}
