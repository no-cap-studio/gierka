using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControlerForGrzib : MonoBehaviour
{
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            this.gameObject.GetComponent<Animator>().Play(rand());
        }
    }
    string rand()
    {
        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            return "idle";
        }
        return "idle2";
    }
}
