using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDrinkEnd : Quest
{
    [SerializeField]
    private FoodAndDrinks foodAndDrinkControl;

    public override void Check()
    {
        base.Check();
        Done = foodAndDrinkControl.CheckDrink();
    }
}
