using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMinCamrea : MonoBehaviour
{
    public GameObject minCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            minCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            Debug.Log(collision.gameObject.name);
        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            minCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            //Debug.Log(collision.gameObject.name);
        }
    }
}
