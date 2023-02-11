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
    public int wybor = 0;
    public bool przelacznik = true;
    public GameObject wybornik;
    public bool bababoe = false;
    public bool bruh = false;
    public GameObject dziubenadoktora;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pierwszy = golomp.GetComponent<golomp_dajalog>().jeden; 
        
        if (bababoe && gracz.GetComponent<dialogi>().tab.Count == 0)
        {
            wybornik.SetActive(true);
        }
        if (bababoe && wybor != 0)
        {
            bababoe = false;
            wybornik.SetActive(false);
            if (wybor == 1)
            {
                gracz.GetComponent<playerMovement>().ruch = false;
                gracz.GetComponent<dialogi>().dziala = true;
                gracz.GetComponent<dialogi>().liczba = 0;
                gracz.GetComponent<dialogi>().napis.text = "Nie! Szef kocha Tuptusia.";
                gracz.GetComponent<dialogi>().tab.Add("Nie! Szef kocha Tuptusia.");
                gracz.GetComponent<dialogi>().tab.Add("Nawet dzisiaj œmia³ siê z ciebie, ¿e pracujesz za darmo.");
                gracz.GetComponent<dialogi>().tab.Add("Wredny ma³piszon k³amie!");
                gracz.GetComponent<dialogi>().tab.Add("S³uchaj, Bonzo mnie te¿ wykorzstuje, raz przez niego skoñczy³em w szpitalu. Ciebie u¿ywa jako ochroniarza i darmow¹ si³ê robocz¹.");
                gracz.GetComponent<dialogi>().tab.Add("To jak, utrzemy mu nosa? Zatrzymamy banany i zarobimy z tego wiêcej ni¿ od szefa.");
                gracz.GetComponent<dialogi>().tab.Add("Ja Tuptuœ! Dobra.");
                bruh = true;

            }
            else if (wybor == 2)
            {
                gracz.GetComponent<playerMovement>().ruch = false;
                gracz.GetComponent<dialogi>().dziala = true;
                gracz.GetComponent<dialogi>().liczba = 0;
                gracz.GetComponent<dialogi>().tab.Add("Dobra, to lecimy z towarem do szefa.");
                gracz.GetComponent<dialogi>().napis.text = "Dobra, to lecimy z towarem do szefa.";
                bruh = true;
            }
        }
        if(bruh && gracz.GetComponent<dialogi>().tab.Count == 0)
        {
            dziubenadoktora.SetActive(true);
            Time.timeScale = 0;
        }
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
        else if(!jedenen && gracz.GetComponent<playerMovement>().licznik == 5 && Input.GetKeyDown(KeyCode.E))
        {
            gracz.GetComponent<dialogi>().tab.Clear();
            gracz.GetComponent<playerMovement>().ruch = false;
            gracz.GetComponent<dialogi>().dziala = true;
            gracz.GetComponent<dialogi>().liczba = 0;
            gracz.GetComponent<dialogi>().napis.text = "Uda³o ci siê coœ znaleŸæ?";
            gracz.GetComponent<dialogi>().tab.Add("Uda³o ci siê coœ znaleŸæ ? ");
            gracz.GetComponent<dialogi>().tab.Add("Ja tuptuœ!");
            gracz.GetComponent<dialogi>().tab.Add("O cholibka, nieŸle, szef zdecydowanie ciê nie docenia.");
            gracz.GetComponent<dialogi>().tab.Add("Ja Tuptuœ! Szef jak ojciec, dobry.");
            gracz.GetComponent<dialogi>().tab.Add("Tuptuœ mam dla cieie propozycje");
            bababoe = true;          
            
        }
        
       
    }
}
