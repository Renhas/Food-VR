using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCookies : Quest
{
    [SerializeField]
    private Collider cookieSpawner;
    [SerializeField]
    private Transform customerElements;
    private GameObject cookiesPlate;
    void Start()
    {
        
    }

    public override void StartQuest()
    {
        base.StartQuest();
        cookiesPlate = customerElements.GetComponentInChildren<Cookies>().transform.GetChild(0).gameObject;
        cookieSpawner.enabled = true;
    }

    public override void Check()
    {
        base.Check();
        Done = cookiesPlate.activeSelf;
    }
}
