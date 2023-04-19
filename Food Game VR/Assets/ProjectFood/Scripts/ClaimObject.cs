using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClaimObject : MonoBehaviour
{
    public GameObject generatebleObject;
    private EventTrigger trigger;
    private InvManager manager;

    void Start() 
    {
        trigger = GetComponent<EventTrigger>();
        manager = GameObject.Find("Inventory").GetComponent<InvManager>();

        CreateTrigger();
    }

    public void Claim() 
    {
        if (!manager.IsEmpty) return;
        GameObject newObj = Instantiate(generatebleObject);
        manager.Set(newObj);
    }

    private void CreateTrigger() 
    {
        if (trigger == null) 
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry action = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerClick
        };
        action.callback.AddListener((eventData) => Claim());

        trigger.triggers.Add(action);
    }
}
