using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFoodEgg : Quest
{
    [SerializeField]
    private InvManager inventory;
    [SerializeField]
    private Collider pan;
    [SerializeField]
    private GameObject TP;
    public override void StartQuest()
    {
        base.StartQuest();
        pan.enabled = true;
        TP.SetActive(true);
    }

    public override void Check()
    {
        base.Check();
        Cook egg = inventory.Get()?.GetComponentInChildren<Cook>();
        Debug.Log(egg);
        if (egg != null) { Debug.Log(egg.isCooked); }
        if (egg != null && egg.isCooked) 
        {
            Done = true;
        }
    }
}
