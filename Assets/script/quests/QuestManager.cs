using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public List<Button> questsButtons;
    public TextMeshProUGUI[] podpunkty;
    public SpriteRenderer[] checks;
    public TextMeshProUGUI nazwa;
    public GameObject complete;
    void Start()
    {
        checks = check.GetComponentsInChildren<SpriteRenderer>();
        podpunkty = podpunkt.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < questsButton.transform.childCount; i++)
        {
            karteczki.Add(questsButton.transform.GetChild(i).gameObject);
        }
        foreach (GameObject g in karteczki)
        {
            questsButtons.Add(g.GetComponentInChildren<Button>());
        }

        foreach (TextMeshProUGUI text in podpunkty) {
            text.gameObject.SetActive(false);
        }

        foreach(SpriteRenderer check in checks) {
            check.gameObject.SetActive(false);
        }
        
    }

    void Update()
    {
        
    }

    public void questTriger(Quest q)
    {
        quests.Add(q);
        questsButtons[quests.IndexOf(q)].GetComponentInChildren<TextMeshProUGUI>().text = q.name;
        karteczki[quests.IndexOf(q)].SetActive(true);
       

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
        foreach (Quest q in quests)
        {
            if (q.checks[0].IsActive == false)
            {
                q.checks[0].IsActive = true;
            }
        }
        notesik.SetActive(!notesik.activeSelf);
        if (notesik.activeSelf)
        {
            //Time.timeScale = 0;
        }
        else {
            //Time.timeScale = 1;
        }

        if (quests.Count > 0)
        {
            nazwa.text = quests[0].name;
            
            int i = 0;
            foreach (questCheck check in quests[0].checks)
            {

                if (check.IsActive == true)
                {
                    podpunkty[i].gameObject.SetActive(true);
                    podpunkty[i].text = check.nameOfCheck;
                    if (check.Done == true)
                    {
                        Debug.Log("odpalam");
                        checks[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        checks[i].gameObject.SetActive(false);
                    }
                }
                else {
                    podpunkty[i].gameObject.SetActive(false);
                    podpunkty[i].text = "";
                }
                
                
                i++;
            }
            if (quests[0].done == true)
            {
                complete.SetActive(true);
            }
            else
            {
                complete.SetActive(false);
            }
        }
        
    }

    public void changeQuest()
    {
        int i = 0;
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        Debug.Log(questsButtons.IndexOf(EventSystem.current.currentSelectedGameObject.GetComponent<Button>()));
        nazwa.text = quests[questsButtons.IndexOf(EventSystem.current.currentSelectedGameObject.GetComponent<Button>())].name;
        foreach (questCheck check in quests[questsButtons.IndexOf(EventSystem.current.currentSelectedGameObject.GetComponent<Button>())].checks)
        {

            if (check.IsActive == true)
            {
                podpunkty[i].gameObject.SetActive(true);
                podpunkty[i].text = check.nameOfCheck;
                if (check.Done == true)
                {
                    Debug.Log("odpalam");
                    checks[i].gameObject.SetActive(true);
                }
                else
                {
                    checks[i].gameObject.SetActive(false);
                }
            }
            else
            {
                podpunkty[i].gameObject.SetActive(false);
                podpunkty[i].text = "";
                checks[i].gameObject.SetActive(false);
            }
           
            i++;
        }
        for (int j = 0; j < checks.Length; j++)
        {
            if (j > quests[questsButtons.IndexOf(EventSystem.current.currentSelectedGameObject.GetComponent<Button>())].checks.Count)
            {
                checks[j].gameObject.SetActive(false);
            }
        }
        if (quests[questsButtons.IndexOf(EventSystem.current.currentSelectedGameObject.GetComponent<Button>())].done == true)
        {
            complete.SetActive(true);
        }
        else
        { 
            complete.SetActive(false) ;
        }

    }


    private void bananaQuestCheck()
    {
        foreach (Quest q in quests)
        {
            foreach (questCheck qc in q.checks)
            {
                if (qc.name == "podnieœ banany")
                { 
                    
                }
            }
        }
    }

}
