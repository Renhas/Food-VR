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
        food = Instantiate(foods[Random.Range(0, foods.Count)]);
        drink = Instantiate(drinks[Random.Range(0, drinks.Count)]);
        bar = Instantiate(barOrigin);

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
        return bar.GetComponentInChildren<ProgressBar>().GetProgress() > 0;
    }
}
