using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class questCheck : MonoBehaviour
{
    public Quest quest;
    public string nameOfCheck;
    public QuestManager manager;
    public bool tak0 = false;
    public bool tak1 = false;
    public int ilosc = 0;
    public int max = 0;

    private bool isActive = false;
    public bool IsActive
    {
        get { return isActive; }
        set { activating(); isActive = true; tak0 = isActive; }
    }
    
    private bool done = false;
    public bool Done
    {
        get { return done; }
        set { finish();done = true; tak1 = done; }
    }

    public abstract void activating();
    public abstract void checking();
    public abstract void finish();

}
