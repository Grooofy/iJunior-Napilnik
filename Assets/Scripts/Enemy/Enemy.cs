using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _heath;
    [SerializeField] private float _forcePush;

    private Rigidbody _rigidbody;
    private SphereCollider _collider;
    public int Health => _heath;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Blowup();
        }
    }

    public void TakeDamage(int damage)
    {
        Push();
        _heath = damage;

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