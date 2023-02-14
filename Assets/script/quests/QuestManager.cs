using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    // dodawanie questow ze wzgledow rusznych jest w dialogmanagerze sooorki


    public List<Quest> quests;
    public GameObject notesik;
    public GameObject questsButton;
    public GameObject podpunkt;
    public GameObject check;
    public List<GameObject> karteczki;
    public Button[] questsButtons;
    public  TextMeshProUGUI[] podpunkty;
    public  SpriteRenderer[] checks;

    void Start()
    {
        checks = check.GetComponentsInChildren<SpriteRenderer>();
        podpunkty = podpunkt.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < questsButton.transform.childCount; i++)
        {
            karteczki.Add(questsButton.transform.GetChild(i).gameObject);
        }
        
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

    public void openQuestBook()
    {
        notesik.SetActive(!notesik.activeSelf);
        if (notesik.activeSelf)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }

        
    }
}
