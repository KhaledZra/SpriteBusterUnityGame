using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePickupHandler : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] public GameObject bulletShieldPrefab;
    [SerializeField] public bool isSpeedPickupActive = false;

    private Coroutine _speedCoroutine;
    private float _oldSpeed;
    private GameObject _createdBulletShield;

    private void Start()
    {
        // since this is important
        _oldSpeed = playerObject.GetComponent<Movement>().speed;
    }

    public void ActivateHealthPickup()
    {
        playerObject.GetComponent<HealthHandler>().Heal(1);
    }
    
    public void ActivateSpeedPickup()
    {
        if (!isSpeedPickupActive)
        {
            _speedCoroutine = StartCoroutine(StartSpeedBuff());
        }
        else
        {
            StopCoroutine(_speedCoroutine);
            SetSpeedToNormal(); // Since it probably before did not reset
            _speedCoroutine = StartCoroutine(StartSpeedBuff());
        }
    }
    
    public void ActivateBulletShieldPickup()
    {
        if (_createdBulletShield == null)
        {
            _createdBulletShield = Instantiate(bulletShieldPrefab, playerObject.transform);
        }
        else
        {
            Destroy(_createdBulletShield);
            _createdBulletShield = Instantiate(bulletShieldPrefab, playerObject.transform);
        }
        _createdBulletShield.SetActive(true);
    }

    private IEnumerator StartSpeedBuff()
    {
        playerObject.GetComponent<Movement>().speed *= 2f;
        isSpeedPickupActive = true;

        yield return new WaitForSeconds(10);

        SetSpeedToNormal();
    }

    private void SetSpeedToNormal()
    {
        playerObject.GetComponent<Movement>().speed = _oldSpeed;
        isSpeedPickupActive = false;
    }
}
