using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private GameManager manager;
    private FoodAndDrinks elements;
    private AudioSource arriveSound;

    void Start() 
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        elements = transform.GetChild(0).GetComponentInChildren<FoodAndDrinks>();
        arriveSound = transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        arriveSound.Play();
    }

    void Update() 
    {
        if (elements.transform.childCount < 3) return;
        if (!elements.CheckBar() && elements.transform.childCount == 3)
        {
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
        arriveSound.Play();
        Destroy(gameObject);
    }
}
