using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookOpen : MonoBehaviour
{
    private GameObject menu;
    void Start()
    {
        menu = transform.GetChild(0).gameObject;
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
        action.callback.AddListener((eventdata) => OpenMenu());
        trigger.triggers.Add(action);
    }
    public void OpenMenu() 
    {
        menu.SetActive(true);
    }

    public void CloseMenu() 
    {
        menu.SetActive(false);
    }
}
