using System;
using UnityEngine;
using TMPro;


public class UIHeathEnemy : MonoBehaviour
{
    private Enemy _enemy;
    private TextMeshProUGUI _textHealth;
    private Camera _camera;


    private void OnDisable()
    {
        _enemy.HealthCheanged -= Show;
    }

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
        _textHealth = GetComponentInChildren<TextMeshProUGUI>();
        _enemy.HealthCheanged += Show;
        _camera = Camera.main;
    }

    private void Show(int health)
    {
        _textHealth.text = health.ToString();
    }

    private void Update()
    {
        transform.LookAt(_camera.transform);
    }
}