using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestQueue : MonoBehaviour
{
    private Queue<Quest> quests;
    [SerializeField]
    List<Quest> questsList;
    [SerializeField]
    private GameObject questTable;
    private Text descr;
    private Text title;
    void Start()
    {
        quests = new Queue<Quest>(questsList);
        title = questTable.transform.GetChild(0).gameObject.GetComponent<Text>();
        descr = questTable.transform.GetChild(1).gameObject.GetComponent<Text>();
        Disable();
    }

    void Disable() 
    {
        foreach (Quest quest in quests) 
        {
            quest.pointer?.SetActive(false);
        }
        StartQuest();
    }
    void Update()
    {
        if (quests.Count > 0 && quests.Peek().Done)
        {
            quests.Peek().pointer?.SetActive(false);
            quests.Dequeue();
            StartQuest();
        }
        Check();
    }

    private void Check()
    {
        if (quests.Count == 0)
        {
            descr.text = "";
            title.text = "";
        }
        else
        {
            descr.text = quests.Peek().Description;
            title.text = quests.Peek().Title;
            quests.Peek().Check();
        }
    }

    private void StartQuest() 
    {
        if (quests.Count > 0)
        {
            quests.Peek().pointer?.SetActive(true);
            quests.Peek().StartQuest();
        }
    }
}
