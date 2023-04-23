using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDrinkStart : Quest
{
    [SerializeField]
    private GameObject drinkSpawner;
    private List<Drink> drinks;
    [SerializeField]
    private float progress;

    public override void StartQuest()
    {
        base.StartQuest();
        drinks = new List<Drink>();
        drinkSpawner.SetActive(true);
        StartCoroutine(drinksInit());
    }

    private IEnumerator drinksInit() 
    {
        bool exit = false;
        while (!exit)
        {
            exit = true;
            for (int i = 0; i < drinkSpawner.transform.childCount; i++)
            {
                var child = drinkSpawner.transform.GetChild(i);
                if (child.transform.childCount < 1) 
                {
                    exit = false;
                    break;
                }
                drinks.Add(child.GetChild(0).GetComponent<Drink>());
            }
            yield return null;
        }

    }

    public override void Check()
    {
        base.Check();
        if (drinks.Count != drinkSpawner.transform.childCount) return;
        foreach (var drink in drinks) 
        {
            if (drink.Progress > progress) 
            {
                Done = true;
                return;
            }
        }
    }
}
