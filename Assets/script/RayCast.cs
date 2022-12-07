using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float speed;
    float step;
    Vector2 pozgracza;
    Vector2 pozgraczaray;
    public GameObject gracz;
    public Transform transgracza;
    bool WidzeCieOwO;
    public float maxRadius;
    public float maxAngle;
    bool isInFov = false;
    public Collider2D[] overlaps = new Collider2D[20];
    Vector3 direction;
    Quaternion rotGoal;
    public float rotateSpeed;
    private void Awake()
    {

         transgracza = gracz.GetComponent<Transform>();

    }
    // Start is called before the first frame update
    void Start()
    {
        step = speed * Time.deltaTime;

        

    }

    // Update is called once per frame
    void Update()
    {
        //followStozek();
        pozgracza = new Vector2(transgracza.position.x, transgracza.position.y);
        pozgraczaray = new Vector2(transgracza.position.x - transform.position.x, transgracza.position.y - transform.position.y);
        if (isInFov == true)
        {
            podonzaj();
        }
        
        isInFov = inFov(transform, transgracza, maxAngle, maxRadius);

    }
   
        void podonzaj()
    {
        transform.parent.position = Vector2.MoveTowards(transform.parent.position, pozgracza, step*Time.deltaTime);
        followStozek();
        
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
        Vector3 fovline1 = Quaternion.AngleAxis(maxAngle, transform.forward) * transform.up * maxRadius;
        Vector3 fovline2 = Quaternion.AngleAxis(-maxAngle, transform.forward) * transform.up * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovline2);
        Gizmos.DrawRay(transform.position, fovline1);

        if(!isInFov)
        {
            Gizmos.color = Color.red;
            Debug.Log("1");
        }    
        else
        {
            Gizmos.color = Color.green;
            Debug.Log("2");
        }
            

        Gizmos.DrawRay(transform.position, (transgracza.position - transform.position).normalized * maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.up * maxRadius);
    }

    public bool inFov(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        int count = Physics2D.OverlapCircleNonAlloc(checkingObject.parent.position, maxRadius, overlaps);
        for (int i = 0; i < count + 1; i++)
        {
            if (overlaps[i]!= null)
            {
                if (overlaps[i].transform.position == target.position)
                {
                    Vector2 direct = (target.position - checkingObject.parent.position).normalized;
                    float angle = Vector2.Angle(checkingObject.up, direct);
                    if (angle <= maxAngle)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(checkingObject.transform.position, direct,maxRadius);
                        if(hit.transform == target)
                        {
                            return true;
                        }

                    }
                }

            }

        }
        return false;
    }

    void followStozek()
    {
        Vector3 diff = gracz.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

    }

}


