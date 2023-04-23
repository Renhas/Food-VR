using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDrinkGet : Quest
{
    private InvManager inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<InvManager>();
    }

    public override void StartQuest()
    {
        base.StartQuest();
        GameObject.Find("SpawnerGlass").GetComponent<Collider>().enabled = true;
    }

    public override void Check()
    {
        base.Check();

        Done = !inventory.IsEmpty && inventory.Get().CompareTag("Glass");
    }
}
