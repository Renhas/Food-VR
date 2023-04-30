using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Vector3 _movePos;
    [SerializeField] private float _moveSpeed;
    private Vector3 _startPos;
    void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        Vector3 offset = _movePos * Mathf.PingPong(Time.time * _moveSpeed, 1f);
        transform.position = _startPos + offset;
    }

}
