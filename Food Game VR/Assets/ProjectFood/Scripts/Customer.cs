using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private GameManager manager;
    private FoodAndDrinks elements;

    void Start() 
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        elements = transform.GetChild(0).GetComponentInChildren<FoodAndDrinks>();
    }

    void Update() 
    {
        if (elements.transform.childCount < 3) return;
        if (!elements.CheckBar() && elements.transform.childCount == 3)
        {
            Debug.Log("Bar");
            manager.RemoveScore();
            Leave();
        }
        else if (elements.CheckFood() && elements.CheckDrink()) 
        {
            manager.AddScore();
            Leave();
        }
        
    
    }
    public void Leave()
    {
        Destroy(gameObject);
    }
}
