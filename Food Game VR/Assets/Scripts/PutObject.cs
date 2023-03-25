using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutObject : MonoBehaviour
{
    private InvManager manager;

    void Start()
    {
        manager = GameObject.Find("Inventory").GetComponent<InvManager>();
    }

    public void Put() 
    {
        GameObject newObj = manager.Get();
        if (!newObj) return;

        manager.Clear();
        newObj.transform.parent = transform;
        newObj.transform.localPosition = Vector3.zero;
    }
}
