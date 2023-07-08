using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private bool hasLifeLength = true;
    private float _objectLifeLength = 2.0f;

    private void Awake()
    {
        if (hasLifeLength)
        {
            Destroy(gameObject, _objectLifeLength);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            var healthHandler = other.gameObject.GetComponent<HealthHandler>();
            healthHandler.TakeDamage(damage);
        }
    }
}
