using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int points;
    public TextMeshProUGUI pointSpace;
    public GameObject deadScreen;
    public QuestManager qm;
    void Start()
    {
        deadScreen.SetActive(false);
        qm = FindObjectOfType<QuestManager>();
    }

    
    void Update()
    {
        
    }
    public void EndGame()
    {
        points = 0;
        pointSpace.text = points.ToString();
        deadScreen.SetActive(true);
        Time.timeScale = 0;     
    }
    public void addpoint()
    { 
        points++;
        pointSpace.text = points.ToString();
        qm.bananaQuestCheck();
        
    }

     
}
