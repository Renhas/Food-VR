using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Move : MonoBehaviour
{
    [SerializeField] private Vector3 _movePos;
    [SerializeField] private float _moveSpeed;
    private Vector3 _startPos;
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = _movePos * Mathf.PingPong(Time.time * _moveSpeed, 1f);
        transform.position = _startPos + offset;
    }

}
