using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drink : MonoBehaviour
{
    private GameManager manager;
    private InvManager inv;
    private int currentChild = 0;
    private bool isAnim = false;
    public bool isStatic = false;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        inv = GameObject.Find("Inventory").GetComponent<InvManager>();
        ChildVisible(isStatic);
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
        action.callback.AddListener((eventdata) => AddAndGet());
        trigger.triggers.Add(action);
    }

    public void AddAndGet() 
    {
        if (isAnim || isStatic) return;
        if (currentChild == 3) Get();
        else Add();
    }

    public void Add() 
    {
        var item = inv.Get();
        if (item == null) return;
        var child = transform.GetChild(currentChild);
        if (item.CompareTag("Glass") && currentChild == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            StartCoroutine(Anim());
        }
        else if (item.CompareTag(child.gameObject.tag) && item.layer == child.gameObject.layer)
        {
            child.gameObject.SetActive(true);
            currentChild += 1;
        }
        else return;

        inv.Clear();
    }

    public void Get() 
    {
        inv.Set(gameObject);
    }

    private IEnumerator Anim() 
    {
        isAnim = true;
        var juice = transform.GetChild(1);
        float progress = 0;
        var time = manager.DrinkTime;
        while (progress < time) 
        {
            var new_x_z = Mathf.Lerp(0.65f, 1, progress / time);
            var new_y = Mathf.Lerp(0, 1, progress / time);
            juice.localScale = new Vector3(new_x_z, new_y, new_x_z);
            progress += Time.deltaTime;
            yield return null;
        }

        isAnim = false;
        currentChild = 2;
    }
}
