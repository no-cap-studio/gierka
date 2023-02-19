using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class setMask : MonoBehaviour
{
    public GameObject obiektParent;
    public SpriteRenderer[] obiektChild;
    public string[] names;
    public bool isThere = false;
    BoxCollider2D boxCollider;
    void Start()
    {
        obiektParent = this.gameObject;
        obiektChild = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in obiektChild)
        {
           

            isThere = false;
            foreach (string name in names)
            {
                if (sr.gameObject.name.Contains(name))
                {
                     isThere = true;
                }
            }
            if (!isThere)
            {
                boxCollider = sr.gameObject.AddComponent<BoxCollider2D>();
                boxCollider.isTrigger = true;
            }
                



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
