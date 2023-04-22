using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    private GameManager manager;
    private ProgressBar bar;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (transform.childCount < 3) return;
        bar = transform.GetChild(2).GetComponentInChildren<ProgressBar>();
        if (bar.GetProgress() < 0.5) manager.customerFrozen = true;
    }
}
