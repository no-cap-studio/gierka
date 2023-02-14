using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // dodawanie questow ze wzgledow rusznych jest w dialogmanagerze sooorki


    public List<Quest> quests;
    public GameObject notesik;
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

    public void cecked(questCheck qc)
    {
        foreach (Quest q in quests)
        {
            if (q.checks.Contains(qc))
            {
                int index = q.checks.IndexOf(qc);
                q.checks[index].Done = true;
            }
        }
    }
}
