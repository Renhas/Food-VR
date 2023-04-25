using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShips : MonoBehaviour
{
    private float time;
    [SerializeField]
    private Vector3 movePosition;
    private Vector3 _startPosition;
    private float progress;
    void Start()
    {
        float x = Random.Range(0, 360);
        float y = Random.Range(0, 360);
        float z = Random.Range(0, 360);
        time = Random.Range(0, 15);
        transform.Rotate(x, y, z);
        _startPosition = transform.localPosition;
        //movePosition = Quaternion.Euler(x, y, z) * movePosition;
        movePosition = new Vector3(0, 0, movePosition.z);
        progress = 0;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (progress <= time)
        {
            Vector3 offset = movePosition * Mathf.Lerp(0, 1, progress / time);
            transform.localPosition = _startPosition + offset;
            progress = progress + Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
