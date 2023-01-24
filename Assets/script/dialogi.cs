using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogi : MonoBehaviour
{
    public TMPro.TextMeshProUGUI napis;
    public GameObject gracz;
    public ScriptableObject script;
    public GameObject canvas;
    private int liczba = 0;
    private bool dziala = true;
    string[] tab = {"Jasper musisz ruszyc swoja zmenelona dupe i splacic swoj dlug","Nie mam pieniendze","Oddasz mi w naturze znaczy w bananach, w parku pilnuja skrzyni pelnej bananow"
        ,"A jak mnie zlapia ?","Nie zrobio ci wiekszej krzywdy niz jak ja cie zlape"};
    void Awake()
    {
        
        gracz.GetComponent<playerMovement>().ruch = false;
        napis.text = tab[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(dziala)
        {
            if (Input.GetButtonDown("Jump"))
            {
                liczba++;
                if (liczba > 4)
                {
                    dziala = false;
                    napis.text = "";
                    canvas.SetActive(false);
                    gracz.GetComponent<playerMovement>().ruch = true;
                }
                else
                {
                    napis.text = tab[liczba];
                }
                

            }
        }
        
    }
    
}
