using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [TextArea]
    public string name;
    [TextArea]
    public string description;

    public List<questCheck> checks;
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
