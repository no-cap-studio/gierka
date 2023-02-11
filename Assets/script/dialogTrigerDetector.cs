using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class dialogTrigerDetector : MonoBehaviour
{
    public GameObject button;
    public GameObject dialogMan;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            button.SetActive(true);
            collision.gameObject.GetComponent<playerMovement>().dialogTriger = button.GetComponent<Button>();
        }
        
    }private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            button.SetActive(false);
            collision.gameObject.GetComponent<playerMovement>().dialogTriger = null;
            dialogMan.GetComponent<dialogManager>().endDialogue();
        }
        
    }

}
