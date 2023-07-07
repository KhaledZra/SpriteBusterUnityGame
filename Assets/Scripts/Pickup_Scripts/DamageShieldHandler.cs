using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShieldHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> bulletObjects;
    
    private Vector3 _axis = Vector3.forward;
    private float _angle = 1.0f;
    private float _rotationSpeed = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        //InitializeBulletShield();
        // SetupBulletShield();
    }

    private void Update()
    {
        RotateObject();

        // Check if all are used
        if (CheckIfAnyBulletsAreAlive())
        {
            Destroy(gameObject);
        }
    }

    // private void InitializeBulletShield()
    // {
    //     
    // }

    private void RotateObject()
    {
        transform.Rotate(_axis, _angle * _rotationSpeed);
    }

    private bool CheckIfAnyBulletsAreAlive()
    {
        return bulletObjects.TrueForAll(bullet => bullet == null);
    }
}
