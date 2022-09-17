using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;

    protected void Shoot(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }

    protected void Heal(Enemy enemy)
    {
        enemy.Heal(_damage);
    }
}
