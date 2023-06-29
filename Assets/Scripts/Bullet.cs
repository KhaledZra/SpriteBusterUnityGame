using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _objectLifeLength = 10.0f;

    private void Awake()
    {
        Destroy(gameObject, _objectLifeLength);
    }

    // // Kill what bullet hits
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            var killCountScript = GameObject.FindWithTag("KillCount").GetComponent<UpdateKillCounter>();
            killCountScript.AddKill();
        }
    }
}
