using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [TextArea]
    public string Description;
    public string Title;
    public bool Done = false;
    [SerializeField]
    public GameObject pointer;

    public virtual void Check() 
    {
        if (Done) return;
    }

    public virtual void StartQuest() 
    {
        Done = false;
    }
}
