using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private enum GunTypes
    {
        Pistol,
        Shotgun,
        Rifle,
        MachineGun,
        GrenadeLauncher,
    }
    
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Transform spawnObject;
    [SerializeField] private float bulletForce = 5.0f;
    [SerializeField] private float fireRate = 1.0f;
    [SerializeField] private GunTypes gunTypes = GunTypes.Pistol;
    [SerializeField] private List<Transform> shotgunSpawnObjects;
    
    private float _timeBetweenShot = 0.0f;


    void Update()
    {
        if (Time.time < fireRate + _timeBetweenShot)
        {
            return;
        }
        
        if(Input.GetKey(KeyCode.Mouse0))
        {
            ShootSelectedWeapon();
            _timeBetweenShot = Time.time;
        }
    }

    private void ShootSelectedWeapon()
    {
        if (gunTypes == GunTypes.Shotgun)
        {
            ShootShotgun();
        }
        else
        {
            ShootWeapon();
        }
    }

    private void ShootWeapon()
    {
        GameObject newBullet = Instantiate(this.bulletObject, spawnObject.position, spawnObject.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = spawnObject.up * bulletForce;
    }
    
    private void ShootShotgun()
    {
        shotgunSpawnObjects.ForEach(spawnObject =>
        {
            GameObject newBullet = Instantiate(bulletObject, spawnObject.position, spawnObject.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = spawnObject.up * bulletForce;
        });
    }
}
