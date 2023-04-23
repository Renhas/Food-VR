using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDrinkLemon : Quest
{
    [SerializeField]
    private List<GameObject> toActiveObject;
    [SerializeField]
    private List<Collider> toActiveCollider;
    private InvManager inventory;
    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<InvManager>();
    }

    public override void StartQuest()
    {
        base.StartQuest();
        foreach(var obj in toActiveObject) obj.SetActive(true);
        foreach (var col in toActiveCollider) col.enabled = true;
    }

    public override void Check()
    {
        base.Check();
        var item = inventory.Get();
        if (item != null)
            Done = item.CompareTag("Lemon");
    }
}
