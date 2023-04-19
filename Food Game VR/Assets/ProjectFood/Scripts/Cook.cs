﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{
    private GameManager manager;
    public bool isCooked = false;
    
    
    void Start() 
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public IEnumerator Cooking() 
    {
        isCooked = false;
        float progress = 0;
        if (manager == null) Start();
        var time = manager.GrillTime;
        while (progress < time) 
        {
            var new_s = Mathf.Lerp(0, 1, progress / time);
            transform.localScale = new Vector3(new_s, 1, new_s);
            progress += Time.deltaTime;
            yield return null;
        }
        isCooked = true;
    }


}
