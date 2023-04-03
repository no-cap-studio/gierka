using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ekwipunek : MonoBehaviour
{
    public TextMeshProUGUI tekst;
    public GameObject[] kratki;
    public GameObject UiInwentarz;
    public GameObject Ramka;
    public GameObject Minimapa;
    public GameObject Czerwony_kwadrat;
    kratka[] inwentarz = new kratka[8];
    private bool inwentarzOtworzony;
    public struct kratka
    {
        
        public int amount;
        public bool InPossesion;
        public bool Blocked;
        public string nazwa;

    }
    public void Setter(int id)
    {
        
        inwentarz[id].amount += 1;
        aktualizacja();
    }
    public bool oddaj(int id,int ilosc)
    {
        if (inwentarz[id].amount < ilosc)
        {
            return false;
        }
        inwentarz[id].amount -= ilosc;
        return true;
    }
    public void aktualizacja()
    {
        for (int i = 0; i < kratki.Length; i++)
        {
            if (inwentarz[i].amount != 0)
            {
                inwentarz[i].InPossesion = true;
            }
            if (inwentarzOtworzony == true)
            {
                for(int j = 0;j < kratki.Length;j++)
                {
                    if (inwentarz[j].InPossesion == true)
                    {
                        kratki[j].SetActive(true);
                        tekst = kratki[j].GetComponentInChildren<TextMeshProUGUI>();
                        tekst.text = inwentarz[j].amount.ToString();
                    }
                }
            }
        }
    }
    public void Pokazlubschowaj()
    {
        Czerwony_kwadrat.SetActive(!Czerwony_kwadrat.activeSelf);
        Ramka.SetActive(!Ramka.activeSelf);
        Minimapa.SetActive(!Minimapa.activeSelf);
        UiInwentarz.SetActive(!UiInwentarz.activeSelf);
      for(int i = 0;i< kratki.Length;i++)
        {
            if (inwentarz[i].InPossesion == true)
            {
                kratki[i].SetActive(!(kratki[i].activeSelf));
                tekst = kratki[i].GetComponentInChildren<TextMeshProUGUI>();
                tekst.text = inwentarz[i].amount.ToString();
            }
        }  
    }
    // Id przedmiotu nie jest nam potrzebne poniewa¿ nie bêdzie mo¿na przenosiæ przedmiotów w eq
    // W zwi¹zku z tym samo po³o¿enie kratki w tablicy bêdzie s³u¿y³o za id przedmiotu
    // Tutaj w komentarzu bêdzie mo¿na zapisaæ która kratka przetrzymuje dany przedmiot;
    // blocked oznacza ¿e z powodów fabularnych nie mo¿emy u¿yæ danego przedmiotu
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<inwentarz.Length;i++)
        {
            inwentarz[i].amount = 0;
            inwentarz[i].InPossesion = false;
            inwentarz[i].Blocked = false;
        }
        Setter(0);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.I))
        {
            Pokazlubschowaj();
        }
    }
    
}
