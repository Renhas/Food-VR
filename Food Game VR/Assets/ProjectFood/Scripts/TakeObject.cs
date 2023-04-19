using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    private InvManager manager;

    void Start()
    {
        manager = GameObject.Find("Inventory").GetComponent<InvManager>();
    }

    public void Take() 
    {
        manager.Set(gameObject);
    }
}
