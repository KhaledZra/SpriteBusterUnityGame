using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] public Transform chaseTarget;
    [SerializeField] public float chaseSpeed = 1.0f;
    [SerializeField] private bool isCaughtUp = false;
    [SerializeField] private int damage = 1; 

    private Vector3 newLocation;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCaughtUp == false)
        {
            newLocation = Vector3.zero;
        }

        if (_transform.position.x < chaseTarget.position.x) // player: 8.604879 | enemy: 4.320901
        {
            if ((_transform.position.x - chaseTarget.position.x) < -0.05f)
            {
                newLocation.x = chaseSpeed * Time.deltaTime;
            }
        }
        else if (_transform.position.x > chaseTarget.position.x) 
        {
            if ((_transform.position.x - chaseTarget.position.x) > 0.05f)
            {
                newLocation.x = -chaseSpeed * Time.deltaTime;
            }
        }

        if (_transform.position.y < chaseTarget.position.y) // -5.217199 | -1.131049
        {
            if ((_transform.position.y - chaseTarget.position.y) < -0.05f)
            {
                newLocation.y = chaseSpeed * Time.deltaTime;
            }
        }
        else if (_transform.position.y > chaseTarget.position.y)
        {
            if ((_transform.position.y - chaseTarget.position.y) > 0.05f)
            {
                newLocation.y = -chaseSpeed * Time.deltaTime;
            }
        }


        if (newLocation != Vector3.zero)
        {
            _transform.position += newLocation;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // todo remove and make better later, this is for debug development
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthHandler>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
