using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> weaponPrefabs;
    [SerializeField] private int selectedWeapon = 0;

    private GameObject _selectedWeaponInstance;
    private bool _isCooldownActive = false;

    private void Start()
    {
        LoadWeapon();
    }

    private void Update()
    {
        if (!_isCooldownActive)
        {
            if (Input.GetKey("1") && (selectedWeapon != 0))
            {
                selectedWeapon = 0;
                SwapWeapon();
            }
            else if (Input.GetKey("2") && (selectedWeapon != 1))
            {
                selectedWeapon = 1;
                SwapWeapon();
            }
            else if (Input.GetKey("3") && (selectedWeapon != 2))
            {
                selectedWeapon = 2;
                SwapWeapon();
            }
            else if (Input.GetKey("4") && (selectedWeapon != 3))
            {
                selectedWeapon = 3;
                SwapWeapon();
            }
        }
    }

    private void LoadWeapon()
    {
        _selectedWeaponInstance = Instantiate(weaponPrefabs[selectedWeapon], transform);
        _selectedWeaponInstance.SetActive(true);
    }

    private void SwapWeapon()
    {
        if (_selectedWeaponInstance != null)
        {
            Destroy(_selectedWeaponInstance);
            LoadWeapon();
            StartCoroutine(SwapCooldown());
        }
    }

    private IEnumerator SwapCooldown()
    {
        _isCooldownActive = true;
        yield return new WaitForSeconds(1f);
        _isCooldownActive = false;
    }
}
