using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBook : Quest
{
    private GameObject player;
    private GameObject book;
    [SerializeField]
    float distanceToBook;
    void Start()
    {
        player = GameObject.Find("Player");
        book = GameObject.Find("Book");
    }

    public override void Check()
    {
        base.Check();
        var distance = (book.transform.position - player.transform.position).magnitude;
        if (distance <= distanceToBook) 
        {
            
            Done = true;
            book.GetComponent<BoxCollider>().enabled = true;
        }
        
    }

}
