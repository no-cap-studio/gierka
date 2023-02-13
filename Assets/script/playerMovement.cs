using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float inputX, inputY;
    public bool ruch;
    public GameObject dialogTriger;
    public Button nextSentence;
    public bool isTalking = false;
    public GameManager manager;
    public bool isHiding = false;
    public hiding hideMet;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ruch == true && isHiding == false)
        {

            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
            movement();
            trigerTalk();
            hiding();   
            
        }
        else if (isHiding == true)
        {
            if (hideMet != null)
            {
                Debug.Log("jestem tu");
                hideMet.choosingPosition();
                hideMet.unhide();
                
            }
           
        }
        
    }

    void movement()
    {
        if(Input.GetAxis("Horizontal")!=0)
        {
            transform.Translate(Vector2.right *inputX * movementSpeed * Time.deltaTime);
        }
        
        if(inputY!=0)
        {
            transform.Translate(Vector2.up * inputY * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            inputX = 0;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y,0);



    }

    public void trigerTalk()
    {

        if (dialogTriger != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isTalking == false)
                {
                    dialogTriger.GetComponent<DialogueTrigger>().triggerDialogue(); ;
                }
                else
                {
                    nextSentence.onClick.Invoke();
                }
            }
        }
    }

    public void hiding()
    {
        if (hideMet != null && Input.GetKeyDown(KeyCode.F))
        {
            hideMet.hidinges();
        }
    }



    public void OnCollisionStay2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("enemy") && CompareTag("Player"))
        {
            manager.EndGame();
        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("banana"))
        {
            Destroy(collision.gameObject);
            manager.addpoint();
        }
    }
}
