using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.Find("MainPlayer").transform;
    }

    void Update()
    {
        transform.LookAt(player);
    }
}
