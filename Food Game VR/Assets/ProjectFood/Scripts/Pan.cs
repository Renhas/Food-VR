using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pan : MonoBehaviour
{
    private InvManager inv;
    private GameObject child;
    [SerializeField]
    private GameObject generatable;
    
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<InvManager>();
        child = transform.GetChild(0).gameObject;
        child.SetActive(false);
        TriggerCreate();
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

    public void AddAndGet()
    {
        if (inv.IsEmpty) Get();
        else Add();
    }

    public void Add() 
    {
        var item = inv.Get();
        if (item.transform.childCount > 0)
        {
            item = item.transform.GetChild(0).gameObject;
        }
        if (!item.CompareTag("Egg")) return;
        if (item.GetComponent<Cook>().isCooked) return;

        child.SetActive(true);
        StartCoroutine(child.GetComponent<Cook>().Cooking());
        
        inv.Clear();
    }

    public void Get() 
    {
        if (!child.activeSelf) return;
        if (!child.GetComponent<Cook>().isCooked) return;

        var item = Instantiate(generatable);
        item.transform.GetChild(0).gameObject.GetComponent<Cook>().isCooked = true;
        inv.Set(item);

        child.SetActive(false);
    }
}
