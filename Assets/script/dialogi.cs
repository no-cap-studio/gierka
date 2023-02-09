using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogi : MonoBehaviour
{
    public TMPro.TextMeshProUGUI napis;
    public GameObject gracz;
    public ScriptableObject script;
    public GameObject canvas;
    public int liczba = 0;
    public bool dziala = true;
    public List<string> tab = new List<string>();
    public string[] tablicunia = { "Jasper! Dosz³y mnie s³uchy o nowym towarze na ulicach - ¿ó³ty, s³odki, a tuptuœ fika³ po nim przez trzy dni.", " Mówi¹ na niego banany. Im wiêcej informacji na jego temat znajdziesz - tym lepiej."," Mój informator czeka na ciebie w parku, wyci¹gnij od niego wiêcej informacji." };


    void Awake()
    {
        tab = 
        gracz.GetComponent<playerMovement>().ruch = false;
        napis.text = tab[0];

    }

    // Update is called once per frame
    void Update()
    {
        if(dziala)
        {
            canvas.SetActive(true);
            if (Input.GetButtonDown("Jump"))
            {
                liczba++;
                if (liczba > tab.Count-1)
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
