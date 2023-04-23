using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class QuestDrinkTP : Quest
{
    [SerializeField]
    private GameObject customer;
    [SerializeField]
    private GameObject drinkTP;
    [SerializeField]
    private float distanceToTP;
    private GameObject player;

    void Start() 
    {
        player = GameObject.Find("Player");
    }

    public override void StartQuest()
    {
        base.StartQuest();
        customer.SetActive(true);
        drinkTP.SetActive(true);
    }

    public override void Check()
    {
        base.Check();
        var distance = (drinkTP.transform.position - player.transform.position).magnitude;
        if (distance <= distanceToTP)
        {
            Done = true;
        }
    }
}
