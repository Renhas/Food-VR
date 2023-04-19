using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cookies : MonoBehaviour
{
    private InvManager inv;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<InvManager>();
        transform.GetChild(0).gameObject.SetActive(false);
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
        action.callback.AddListener((eventdata) => Add());
        trigger.triggers.Add(action);
    }

    public void Add()
    {
        if (inv.IsEmpty) return;
        var item = inv.Get();
        var child = transform.GetChild(0).gameObject;
        if (child.activeSelf) return;
        if (!item.CompareTag(child.tag) || item.layer != child.layer) return;

        child.gameObject.SetActive(true);
        transform.parent.GetComponentInChildren<ProgressBar>().GiveCookies();

        inv.Clear();
    }
}
