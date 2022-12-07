using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    GameObject obrazek;
    Image obraz;
    public float speed;
    float step;
    Vector2 pozgracza;
    Vector2 pozgraczaray;
    GameObject gracz;
    public Transform transgracza;
    bool WidzeCieOwO;
    public float maxRadius;
    public float maxAngle;
    bool isInFov = false;
    public Collider2D[] overlaps = new Collider2D[20];
    private void Awake()
    {
         gracz = GameObject.FindWithTag("Player");
        transgracza = gracz.GetComponent<Transform>();

    }
    // Start is called before the first frame update
    void Start()
    {
        step = speed * Time.deltaTime;
        obrazek = GameObject.FindWithTag("smierc");
        obraz = obrazek.GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        
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
        transform.position = Vector2.MoveTowards(transform.position, pozgracza, step);
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
        int count = Physics2D.OverlapCircleNonAlloc(checkingObject.position, maxRadius, overlaps);
        for (int i = 0; i < count + 1; i++)
        {
            if (overlaps[i]!= null)
            {
                if (overlaps[i].transform.position == target.position)
                {
                    Vector2 direct = (target.position - checkingObject.position).normalized;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            obraz.enabled = true;
        }
    }
}


