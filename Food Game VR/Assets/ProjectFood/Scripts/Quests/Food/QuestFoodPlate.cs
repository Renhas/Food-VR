using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFoodPlate : Quest
{
    [SerializeField]
    private Collider plateSpawner;
    [SerializeField]
    private GameObject customerElements;
    private Plate plate;

    public override void StartQuest()
    {
        base.StartQuest();
        plateSpawner.enabled = true;
        plate = customerElements.transform.GetChild(1).GetComponentInChildren<Plate>();
    }

    public override void Check()
    {
        base.Check();
        Done = plate.isDone;
    }
}
