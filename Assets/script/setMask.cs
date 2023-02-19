using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMask : MonoBehaviour
{
    public GameObject obiektParent;
    public SpriteRenderer[] obiektChild;
    public string[] names;
    public bool isThere = false;
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
                    isThere= true;
                }
            }
            if (!isThere)
            {
                sr.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
                Debug.Log(sr.gameObject.name);
            }
                



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
