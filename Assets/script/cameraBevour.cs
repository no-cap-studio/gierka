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


    void LateUpdate()
    {
        follow();
        changingCameraRotation();
    }

    void follow()
    {
        Vector3 desiredPosition = target.transform.position + positionOffSet;
        smoothnedMovement = Vector3.Lerp(transform.position, desiredPosition, smoothness);
        transform.position = smoothnedMovement;
    }
    void changingCameraRotation()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            Vector3 axis= new Vector3(0,1,0);
            transform.RotateAround(target.transform.position, axis, 90);
            
        }
        
        
    }
}
