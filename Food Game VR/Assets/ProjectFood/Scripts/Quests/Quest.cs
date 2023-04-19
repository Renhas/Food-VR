using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string Description;
    public string Title;
    public bool Done = false;
    [SerializeField]
    protected GameObject pointer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointer?.SetActive(!Done);
    }

    public virtual void Check() 
    {
        if (Done) return;
    }
}
