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

        if (target.transform.position.y > minPos.y && target.transform.position.x < maxPos.x && target.transform.position.y < maxPos.y && target.transform.position.x > minPos.x)
        {
            Vector3 desiredPosition = target.transform.position + positionOffSet;
            smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
            transform.position = smoothnedMovement;
        }
        else
        {

            if (target.transform.position.x >= maxPos.x && target.transform.position.y <= minPos.y)
            {
                Vector3 desiredPosition = new Vector3(maxPos.x, minPos.y, -1);
                smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
                transform.position = smoothnedMovement;
            }
            else if(target.transform.position.x >= maxPos.x && target.transform.position.y >= maxPos.y)
            {
                Vector3 desiredPosition = new Vector3(maxPos.x, maxPos.y, -1);
                smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
                transform.position = smoothnedMovement;
            }
            else if (target.transform.position.x <= minPos.x && target.transform.position.y <= minPos.y)
            {
                Vector3 desiredPosition = new Vector3(minPos.x, minPos.y, -1);
                smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
                transform.position = smoothnedMovement;
            }
            else if (target.transform.position.x <= minPos.x && target.transform.position.y >= maxPos.y)
            {
                Vector3 desiredPosition = new Vector3(minPos.x, maxPos.y, -1);
                smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
                transform.position = smoothnedMovement;
            }
            else if (target.transform.position.x >= maxPos.x)
            {
                Vector3 desiredPosition = new Vector3(maxPos.x, target.transform.position.y + positionOffSet.y, -1);
                smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
                transform.position = smoothnedMovement;
            }
            else if (target.transform.position.x <= minPos.x)
            {
                Vector3 desiredPosition = new Vector3(minPos.x, target.transform.position.y + positionOffSet.y, -1);
                smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
                transform.position = smoothnedMovement;
            }
            else if (target.transform.position.y >= maxPos.y)
            {
                Vector3 desiredPosition = new Vector3(target.transform.position.x + positionOffSet.x, maxPos.y, -1);
                smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
                transform.position = smoothnedMovement;
            }
            else if (target.transform.position.y <= minPos.y)
            {
                Vector3 desiredPosition = new Vector3(target.transform.position.x + positionOffSet.x, minPos.y, -1);
                smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
                transform.position = smoothnedMovement;
            }
        }

    }
  
}
