using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animOnClose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            this.gameObject.GetComponent<Animator>().SetBool("isClose", true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            this.gameObject.GetComponent<Animator>().SetBool("isClose", false);
    }
}
