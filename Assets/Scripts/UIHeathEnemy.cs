using System;
using UnityEngine;
using TMPro;


public class UIHeathEnemy : MonoBehaviour
{
    private Enemy _enemy;
    private TextMeshProUGUI _textHealth;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _enemy = GetComponentInParent<Enemy>();
        _textHealth = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        _textHealth.text = _enemy.Health.ToString();
    }

    private void Update()
    {
        transform.LookAt(_camera.transform);
    }
}