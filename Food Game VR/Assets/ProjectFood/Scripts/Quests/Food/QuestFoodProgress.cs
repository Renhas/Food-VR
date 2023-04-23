using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFoodProgress : Quest
{
    [SerializeField]
    private Transform customerElements;
    [SerializeField]
    private float progress;
    private Food food;

    public override void StartQuest()
    {
        base.StartQuest();
        food = customerElements.GetComponentInChildren<Food>();
    }

    public override void Check()
    {
        base.Check();
        Done = food.Progress > progress;
    }
}
