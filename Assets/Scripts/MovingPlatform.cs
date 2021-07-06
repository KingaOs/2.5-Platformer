using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    private Transform _currentTarget;
    [SerializeField]
    private float _speed;

    void Start()
    {
        _currentTarget= _targetB;
    }

    void FixedUpdate()
    { 
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, Time.deltaTime * _speed);

        if (transform.position == _targetA.position)
        {
            _currentTarget = _targetB;
        }
        else if (transform.position == _targetB.position)
        {
            _currentTarget = _targetA;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
