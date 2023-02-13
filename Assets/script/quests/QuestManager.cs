using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // dodawanie questow ze wzgledow rusznych jest w dialogmanagerze sooorki


    public List<Quest> quests;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void questTriger(Quest q)
    {
        quests.Add(q);
    }
}
