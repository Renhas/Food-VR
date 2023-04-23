using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class QuestFridgeTP : Quest
{
    [SerializeField]
    private GameObject fridgeTP;
    [SerializeField]
    private float distanceToTP;

    public override void StartQuest()
    {
        base.StartQuest();
        fridgeTP.SetActive(true);
    }

    public override void Check()
    {
        base.Check();
        var distance = (fridgeTP.transform.position - fridgeTP.transform.position).magnitude;
        if (distance <= distanceToTP)
        {
            Done = true;
        }
    }
}
