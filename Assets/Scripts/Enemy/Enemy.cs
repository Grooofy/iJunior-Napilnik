using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private int _heath;
    [SerializeField] private float _forcePush;

    private const int MaxHealth = 100;
    public event UnityAction<int> HealthCheanged;

    private Rigidbody _rigidbody;
    private SphereCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        HealthCheanged?.Invoke(_heath);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Blowup();
        }
    }

    public void Heal(int number)
    {
        _heath += number;
        HealthCheanged?.Invoke(_heath);
        if (_heath > MaxHealth)
            _heath = MaxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        Push();
        _heath -= damage;
        HealthCheanged?.Invoke(_heath);
        if (_heath <= 0)
            Die();
    }

    private void Blowup()
    {
        int damage = 50;
        
        TakeDamage(damage);
    }

    private void PlayExplosion()
    {
        Debug.Log("Boom");
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void Push()
    {
        _rigidbody.AddForceAtPosition((Vector3.back + Vector3.up) * _forcePush, transform.position, ForceMode.Impulse);
    }
}