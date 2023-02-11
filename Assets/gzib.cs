using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gzib : MonoBehaviour
{
    public SpriteRenderer gzibencjo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Gzibing()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Gzibing()
    {
        yield return new WaitForSeconds(20);
        gzibencjo.enabled = true;
        yield return new WaitForSeconds(5);
        gzibencjo.enabled = false;

    }
}
