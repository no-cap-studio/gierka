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
    [HideInInspector] public bool isTalking = false;
    public GameManager manager;
    [HideInInspector]public bool isHiding = false;
    [HideInInspector] public hiding hideMet;
    public QuestManager qm;
    public przeszukiwanieKoszy trashCan;
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
            przeszukajKosz();
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

        showQuestLog();
       
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

    public void przeszukajKosz()
    {
        if (trashCan != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("wlacza sie");
            trashCan.startLooking();
        }
    }



    public void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.CompareTag("auto"))
        {
            if (collision.gameObject.GetComponent<carControler>().canMove)
            {
                //Debug.Log("canmove: ");
                //Debug.Log(collision.gameObject.GetComponent<carControler>().canMove);
                manager.EndGame();
            }
           
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            manager.EndGame();
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("banana"))
        {
            collision.gameObject.SetActive(false);
            manager.addpoint();
        }
        if (collision.gameObject.CompareTag("sideQuestIteam"))
        { 
            collision.gameObject.SetActive(false);
        }
    }

    public void showQuestLog()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            qm.openQuestBook();
        }
        
    }
}
