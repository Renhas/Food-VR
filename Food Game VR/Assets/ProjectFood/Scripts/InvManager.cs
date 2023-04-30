using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager : MonoBehaviour
{
    private GameObject object_in_inventory = null;
    public bool IsEmpty { get { return object_in_inventory == null; } }

    public void Set(GameObject obj) 
    {
        if (!IsEmpty) return;
        var collider = gameObject.GetComponent<Collider>();
        object_in_inventory = obj;
        obj.transform.SetParent(transform);
        obj.transform.position = collider.bounds.center;
    }

    public GameObject Get() 
    {
        return object_in_inventory;
    }

    public void Clear() 
    {
        Destroy(object_in_inventory);
        object_in_inventory = null;
    }
}
