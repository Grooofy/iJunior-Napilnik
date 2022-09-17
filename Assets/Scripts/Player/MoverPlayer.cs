using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoverPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    
    private float _movementInput;
    private float _turnInput;
    private Rigidbody _rigidbody;
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _movementInput = Input.GetAxis(Vertical);
        _turnInput = Input.GetAxis(Horizontal);
    }

    private void FixedUpdate()
    {
        Turn();
        Move();
    }
    
    private void Move()
    {
        Vector3 movement = transform.forward * (_movementInput * _speed * Time.fixedDeltaTime);

        _rigidbody.MovePosition(_rigidbody.position + movement);
    }
    
    private void Turn()
    {
        float turn = _turnInput * _turnSpeed * Time.fixedDeltaTime;

        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        _rigidbody.MoveRotation(_rigidbody.rotation * turnRotation);
    }
}
