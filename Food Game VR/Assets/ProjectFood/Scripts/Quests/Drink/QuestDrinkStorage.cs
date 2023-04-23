using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDrinkStorage : Quest
{
    [SerializeField]
    private GameObject storage;
    [SerializeField]
    private Collider door;

    public override void StartQuest()
    {
        base.StartQuest();
        storage.SetActive(true);
        door.enabled = true;
    }

    public override void Check()
    {
        base.Check();
        int count = 0;
        for (int i = 0; i < storage.transform.childCount; i++) 
        {
            if (storage.transform.GetChild(i).gameObject.activeSelf) count++;
            if (count >= 2) 
            {
                Done = true;
                break;
            }
        }


    }

}
