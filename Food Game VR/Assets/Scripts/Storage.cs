using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Storage : MonoBehaviour
{
    private InvManager inv;
    private string storageTag;
    private int count;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<InvManager>();
        storageTag = gameObject.tag;
        CountCheck();
        TriggerCreate();    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TriggerCreate() 
    {
        var trigger = GetComponent<EventTrigger>();
        if (trigger == null) 
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }

        var action = new EventTrigger.Entry()
        {
            eventID = EventTriggerType.PointerClick
        };
        action.callback.AddListener((eventdata) => AddAndGet());
        trigger.triggers.Add(action);
    }

    private void CountCheck() 
    {
        count = 0;
        for (int i = 0; i < transform.childCount; i++) 
        {
            if (transform.GetChild(i).gameObject.activeSelf) count++;
        }
    }
    public void AddAndGet() 
    {
        if (inv.IsEmpty) Get();
        else Add();
    }
    public void Add() 
    {
        if (count == transform.childCount) return;
        var item = inv.Get();
        if (!item.CompareTag(storageTag) || item.layer != LayerMask.NameToLayer("Drink")) return;

        inv.Clear();

        transform.GetChild(count).gameObject.SetActive(true);
        count++;
    }

    public void Get() 
    {
        if (count == 0) return;

        var item = Instantiate(transform.GetChild(count - 1).gameObject);
        inv.Set(item);

        transform.GetChild(count - 1).gameObject.SetActive(false);
        count--;
    }
}
