using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBookClose : Quest
{
    private GameObject book;
    void Start()
    {
        book = GameObject.Find("Book");
    }

    public override void Check()
    {
        base.Check();
        Done = !book.transform.GetChild(0).gameObject.activeSelf;
    }
}
