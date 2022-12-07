using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    GameObject obrazek;
    Image obraz;
    GameObject tekscik;
    TextMeshProUGUI Tekst;
    public GameObject player;
    public float movementSpeed;
    public float inputX, inputY;
    public int punkty=0;
    public bool wygrana;
    void Start()
    {
        obrazek = GameObject.FindWithTag("wygrama");
        obraz = obrazek.GetComponent<Image>();
        tekscik = GameObject.FindWithTag("tekst");
        Tekst = tekscik.GetComponent<TextMeshProUGUI>();
        
    }


    void Update()
    {
        Tekst.text = punkty.ToString();
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        movement();
    }

    void movement()
    {
        if(Input.GetAxis("Horizontal")!=0)
        {
            player.transform.Translate(Vector2.right *inputX * movementSpeed * Time.deltaTime);
        }
        
        if(inputY!=0)
        {
            player.transform.Translate(Vector2.up * inputY * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            inputX = 0;
        }

        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,0);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Banan")
        {
            
            Destroy(collision.gameObject);
            punkty += 1;
            
            if (punkty == 5)
            {
                
                wygrana = true;
                Debug.Log("Yems");
                obraz.enabled = true;
                Time.timeScale = 0;
            }
        }
    }

}
