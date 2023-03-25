using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composition : MonoBehaviour
{
    public List<string> tagsForComposition;
    // Start is called before the first frame update
    void Start()
    {
        if (tagsForComposition == null) tagsForComposition = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        SortChildren();
    }

    public bool CheckChildren() 
    {
        if (transform.childCount != tagsForComposition.Count) return false;

        var result = true;
        for (int i = 0; i < transform.childCount; i++) 
        {
            if (!transform.GetChild(i).CompareTag(tagsForComposition[i]))
                result = false;
        }
        return result;
    }
    void SortChildren() 
    {
        var parentCollider = gameObject.GetComponent<Collider>();
        float y = 0;
        for (int i = 0; i < transform.childCount; i++) 
        {
            var child = transform.GetChild(i);
            Debug.Log(parentCollider.bounds.center);
            child.localPosition = new Vector3(0, y, 0);
            var collider = child.gameObject.GetComponent<Collider>();
            y += collider.bounds.size.y / transform.localScale.y;
            child.transform.localRotation = new Quaternion();
        }
    }
}
