using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShips : MonoBehaviour
{
    private float time;
    [SerializeField]
    private float moveValue;
    [SerializeField]
    private float minTime;
    [SerializeField]
    private float maxTime;
    private Vector3 _startPosition;
    private float progress;
    void Start()
    {
        float x = Random.Range(0, 360);
        float y = Random.Range(0, 360);
        float z = Random.Range(0, 360);
        time = Random.Range(minTime, maxTime);
        transform.Rotate(x, y, z);
        _startPosition = transform.localPosition;
        progress = 0;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (progress <= time)
        {
            Vector3 offset = moveValue * transform.forward * Mathf.Lerp(0, 1, progress / time);
            transform.localPosition = _startPosition + offset;
            Debug.Log(_startPosition + offset);
            progress = progress + Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
