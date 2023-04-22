using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDrinkTrash : Quest
{
    private InvManager inventory;

    void Start() 
    {
        inventory = GameObject.Find("Inventory").GetComponent<InvManager>();
    }

    public override void StartQuest()
    {
        base.StartQuest();
        GameObject.Find("Sink").GetComponent<Collider>().enabled = true;
    }

    public override void Check()
    {
        base.Check();
        if (inventory.IsEmpty) Done = true;
    }
}
