using System.Collections.Generic;
using UnityEngine;

public class FoodAndDrinks : MonoBehaviour
{
    public List<GameObject> foods;
    public List<GameObject> drinks;
    public GameObject barOrigin;

    private GameObject food;
    private GameObject drink;
    private GameObject bar;

    void Start()
    {
        if (transform.childCount == 0)
        {
            food = Instantiate(foods[Random.Range(0, foods.Count)]);
            drink = Instantiate(drinks[Random.Range(0, drinks.Count)]);
            bar = Instantiate(barOrigin);
        }
        else 
        {
            drink = transform.GetChild(0).gameObject;
            food = transform.GetChild(1).gameObject;
            bar = transform.GetChild(2).gameObject;
        }

        drink.transform.SetParent(transform);
        food.transform.SetParent(transform);
        bar.transform.SetParent(transform);

        food.transform.localPosition = Vector3.zero;
        drink.transform.localPosition = Vector3.zero;
        bar.transform.localPosition = Vector3.zero;
    }

    public bool CheckFood() 
    {
        var script = food.transform.GetChild(1).GetChild(0).GetComponentInChildren<Food>(true);
        return script.isCooked;
    }

    public bool CheckDrink() 
    {
        return drink.transform.GetChild(1).GetChild(0).gameObject.activeSelf;
    }

    public bool CheckBar() 
    {
        var value = bar.GetComponentInChildren<ProgressBar>().GetProgress();
        if (System.Single.IsNaN(value)) return true;
        return value > 0 && value <= 1;
    }
}
