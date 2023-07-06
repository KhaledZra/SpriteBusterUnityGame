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
    
    [SerializeField] private GameObject BulletObject;
    [SerializeField] private Transform SpawnObject;
    [SerializeField] private float BulletForce = 5.0f;
    [SerializeField] private bool IsAutoFire = false;
    [SerializeField] private GunTypes gunTypes = GunTypes.Pistol;
    [SerializeField] private List<Transform> shotgunSpawnObjects;
    
    private bool _isCoolDownActive = false;


    void Update()
    {
        if (!_isCoolDownActive)
        {
            if (Input.GetKey(KeyCode.Mouse0) && IsAutoFire)
            {
                ShootSelectedWeapon();
            }
            else if(Input.GetKeyDown(KeyCode.Mouse0) && !IsAutoFire)
            {
                ShootSelectedWeapon();
            }
        }
    }

    private void ShootSelectedWeapon()
    {
        if (gunTypes == GunTypes.Pistol)
        {
            ShootPistol();
        }
        else if (gunTypes == GunTypes.Shotgun)
        {
            ShootShotgun();
        }
        else if (gunTypes == GunTypes.Rifle)
        {
            ShootRifle();
        }
        else if (gunTypes == GunTypes.MachineGun)
        {
            ShootMachineGun();
        }
        else if (gunTypes == GunTypes.GrenadeLauncher)
        {
            
        }
    }

    private void ShootPistol()
    {
        GameObject bulletObject = Instantiate(BulletObject, SpawnObject.position, SpawnObject.rotation);
        bulletObject.GetComponent<Rigidbody2D>().velocity = SpawnObject.up * BulletForce;
        StartCoroutine(FireRateDelay(0.25f));
    }
    
    private void ShootShotgun()
    {
        shotgunSpawnObjects.ForEach(spawnObject =>
        {
            GameObject bulletObject = Instantiate(BulletObject, spawnObject.position, spawnObject.rotation);
            bulletObject.GetComponent<Rigidbody2D>().velocity = spawnObject.up * BulletForce;
        });
        StartCoroutine(FireRateDelay(1f));
    }
    
    private void ShootRifle()
    {
        GameObject bulletObject = Instantiate(BulletObject, SpawnObject.position, SpawnObject.rotation);
        bulletObject.GetComponent<Rigidbody2D>().velocity = SpawnObject.up * BulletForce;
        StartCoroutine(FireRateDelay(0.1f));
    }
    
    private void ShootMachineGun()
    {
        GameObject bulletObject = Instantiate(BulletObject, SpawnObject.position, SpawnObject.rotation);
        bulletObject.GetComponent<Rigidbody2D>().velocity = SpawnObject.up * BulletForce;
        StartCoroutine(FireRateDelay(0.01f));
    }

    IEnumerator FireRateDelay(float fireRate)
    {
        _isCoolDownActive = true;
        yield return new WaitForSeconds(fireRate);
        _isCoolDownActive = false;
    }
    
    //// Not needed :) but cool solution
    // IEnumerator PhysicsLate (Rigidbody2D rb2d, Vector2 startPosition){
    //     yield return new WaitForSeconds(0.01f);
    //     rb2d.AddForce(new Vector2(20.0f, 20.0f));
    // }
}
