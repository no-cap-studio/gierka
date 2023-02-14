using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class questCheck : MonoBehaviour
{
    public Quest quest;
    public string nameOfQuest;
    public string nameOfCheck;
    public QuestManager manager;
    public bool tak0 = false;
    private bool isActive = false;
    public bool IsActive
    {
        get { return isActive; }
        set { activating(); }
    }
    
    private bool done = false;
    public bool Done
    {
        get { return done; }
        set { finish();tak0 = true; }
    }

    public abstract void activating();
    public abstract void checking();
    public abstract void finish();

}
