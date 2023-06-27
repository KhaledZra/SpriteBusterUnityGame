using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject BulletObject;
    [SerializeField] private Transform SpawnObject;
    [SerializeField] private float BulletForce = 5.0f;
    [SerializeField] private bool IsAutoFire = false;


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && IsAutoFire)
        {
            Shoot();
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && !IsAutoFire)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bulletObject = Instantiate(BulletObject, SpawnObject.position, SpawnObject.rotation);
        bulletObject.GetComponent<Rigidbody2D>().velocity = SpawnObject.up * BulletForce;
    }
    
    //// Not needed :) but cool solution
    // IEnumerator PhysicsLate (Rigidbody2D rb2d, Vector2 startPosition){
    //     yield return new WaitForSeconds(0.01f);
    //     rb2d.AddForce(new Vector2(20.0f, 20.0f));
    // }
}