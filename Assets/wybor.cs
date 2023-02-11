using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wybor : MonoBehaviour
{
    public Button guzik1;
    public Button guzik2;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Podejmijwybor(int liczba)
    {
        enemy.GetComponent<misiodajalog>().wybor = liczba; 
    }
}
