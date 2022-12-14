using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed;
    public float inputX, inputY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
