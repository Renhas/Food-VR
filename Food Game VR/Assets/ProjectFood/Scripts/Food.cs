using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food : MonoBehaviour
{
    private InvManager inv;
    private int currentChild = 0;

    public bool isCooked { get { return currentChild == transform.childCount; } }
    public float Progress { get { return (float)currentChild / transform.childCount; } }
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<InvManager>();
        ChildVisible(false);
        TriggerCreate();
    }

    private void ChildVisible(bool mode)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(mode);
        }
        currentChild = 0;
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
        action.callback.AddListener((eventdata) => Add());
        trigger.triggers.Add(action);
    }

    public void Add()
    {
        if (inv.IsEmpty) return;
        var item = inv.Get();
        var child = transform.GetChild(currentChild).gameObject;
        if (item.CompareTag("Egg") && !item.GetComponentInChildren<Cook>().isCooked) return;
        if (!item.CompareTag(child.tag) || item.layer != LayerMask.NameToLayer("Ing")) return;
        
        child.gameObject.SetActive(true);
        currentChild += 1;

        inv.Clear();
    }
}
