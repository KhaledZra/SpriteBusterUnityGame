using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float speed = 200.0f;
    [SerializeField] private GameObject playerBody;
    
    private Vector2 _currentMovement;

    // Update is called once per frame
    void Update()
    {
        _currentMovement = 
             new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
    }

    void FixedUpdate()
    {
        var rb = playerBody.GetComponent<Rigidbody2D>();
        rb.velocity = _currentMovement * Time.fixedDeltaTime;
    }
}
