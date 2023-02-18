using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [TextArea]
    public string nameOfQuest;
    [TextArea]
    public string description;
    public bool done = false;
    public List<questCheck> checks;
   
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setActive()
    {
        checks[0].IsActive = true;
    }
}
