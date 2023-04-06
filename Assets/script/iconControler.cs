using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconControler : MonoBehaviour
{
    //public GameObject golompIcon;
    //public GameObject misioIcon;
    //public GameObject jasperIcon;
    public List<GameObject> ikonki;
    void Start()
    {
        foreach (GameObject obj in ikonki)
        {
            obj.SetActive(true);
        }
    }

    
    void Update()
    {
        
    }
}
