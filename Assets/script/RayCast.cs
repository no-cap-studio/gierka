using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject[] posterunki;
    public Vector3[] sciezka;
    int liczba = 0;
    public Vector3 cel;
    public GameObject stozek;

    private void Awake()
    {        
            sciezka = new Vector3[posterunki.Length];
            for (int i = 0; i <= posterunki.Length-1; i++)
            {
                sciezka[i] = posterunki[i].transform.position;
            }
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
        
        if (isInFov != true)
        {
            cel = sciezka[liczba];
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, cel, step * Time.deltaTime);
            if (transform.parent.position == sciezka[liczba])
            {
                if (liczba == sciezka.Length-1)
                {
                    liczba = 0;
                    System.Array.Reverse(sciezka);
                }
                else
                {
                    liczba++;
                }

            }
        }

        
        pozgracza = new Vector2(transgracza.position.x, transgracza.position.y);
        pozgraczaray = new Vector2(transgracza.position.x - transform.position.x, transgracza.position.y - transform.position.y);
        if (isInFov == true)
        {
                podonzaj();
                stozek.SetActive(false);
        }
        else
        {
            degreeChecker();
            stozek.SetActive(true);
        }

        isInFov = inFov(transform, transgracza, maxAngle, maxRadius);

        
    }
        void podonzaj()
        {
            cel = pozgracza;
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, pozgracza, step * Time.deltaTime);
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

            if (!isInFov)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
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
                if (overlaps[i] != null)
                {
                    if (overlaps[i].transform.position == target.position)
                    {
                        Vector2 direct = (target.position - checkingObject.parent.position).normalized;
                        float angle = Vector2.Angle(checkingObject.up, direct);
                        if (angle <= maxAngle)
                        {
                            RaycastHit2D hit = Physics2D.Raycast(checkingObject.transform.position, direct, maxRadius);
                            if(hit.transform == target && gracz.CompareTag("Player")) 
                            {
                                return true;
                            }

                        }
                    }

                }

            }
            return false;
        }

    public void degreeChecker()
    {
        if (cel != null)
        {
            if (Mathf.Abs(transform.position.x - cel.x) > Mathf.Abs(transform.position.y - cel.y))
            {
                if (transform.position.x > cel.x)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 90);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, -90);
                }
            }
            else
            {
                if (transform.position.y > cel.y)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f,180);

                }
                else
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 0);

                }
            }
            
        }
        
    }

        void followStozek()
        {
            Vector3 diff = gracz.transform.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }


    IEnumerator Czekaj()
    {
        if (isInFov != true)
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, sciezka[liczba], step * Time.deltaTime);
            if (transform.parent.position == sciezka[liczba])
            {
                if(liczba == 3)
                {
                    liczba = 0;
                    yield return new WaitForSeconds(2);
                }
                else
                {
                    liczba++;
                    yield return new WaitForSeconds(2);
                }

            }


        }
    }
   

}


