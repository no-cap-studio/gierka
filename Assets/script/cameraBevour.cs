using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class cameraBevour : MonoBehaviour
{
    public GameObject target;
    public Vector3 positionOffSet;
    public float smoothness=0.125f;
    public float speed;
    Vector3 smoothnedMovement;
    public Vector2 minPos = new Vector2(2f,2f);
    public Vector2 maxPos = new Vector2(9.8f, -26f);



    void LateUpdate()
    {
        follow();
        
    }

    void follow()
    {
        /*
        if (transform.position.y > minPos.y && transform.position.x < maxPos.x && transform.position.y < maxPos.y && transform.position.x > minPos.x)
        {
            Vector3 desiredPosition = target.transform.position + positionOffSet;
            smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
            transform.position = smoothnedMovement;
        }
        else if (transform.position.x >= maxPos.x || transform.position.x <= minPos.x)
        {
            
        }
        else if (transform.position.y <= minPos.y && transform.position.y >= maxPos.y )
        {

        }
        */
        Vector3 desiredPosition = target.transform.position + positionOffSet;
        smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
        transform.position = smoothnedMovement;

    }
  
}
