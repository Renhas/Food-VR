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
        /*
        quests = new Queue<Quest>();
        foreach (var obj in questsList) 
        {
            quests.Enqueue(obj.GetComponent<Quest>());
        }
        */
        title = questTable.transform.GetChild(0).gameObject.GetComponent<Text>();
        descr = questTable.transform.GetChild(1).gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (quests.Count > 0 && quests.Peek().Done)
            quests.Dequeue();
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
}
