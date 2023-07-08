using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> weaponPrefabs;
    [SerializeField] private int selectedWeapon = 0;
    [SerializeField] private EquippedUiHandler equippedUi;
    [SerializeField] private JsonPlayerDataHandler playerDataHandler;

    private GameObject _selectedWeaponInstance;
    private bool _isCooldownActive = false;
    private PlayerData _playerData;

    private void UpdateUi()
    {
        if (selectedWeapon == 0) equippedUi.UpdateEquipmentUi("Pistol", 0);
        if (selectedWeapon == 1) equippedUi.UpdateEquipmentUi("Shotgun", 1);
        if (selectedWeapon == 2) equippedUi.UpdateEquipmentUi("Rifle", 2);
        if (selectedWeapon == 3) equippedUi.UpdateEquipmentUi("Minigun", 3);
    }

    private void Start()
    {
        _playerData = playerDataHandler.LoadPlayerDataFromJson();
        LoadWeapon();
        UpdateUi();
    }

    private void Update()
    {
        if (!_isCooldownActive)
        {
            if (Input.GetKey("1") && (selectedWeapon != 0))
            {
                selectedWeapon = 0;
                SwapWeapon();
                UpdateUi();
            }
            else if (Input.GetKey("2") && (selectedWeapon != 1) && _playerData.isShotgunUnlocked)
            {
                selectedWeapon = 1;
                SwapWeapon();
                UpdateUi();
            }
            else if (Input.GetKey("3") && (selectedWeapon != 2) && _playerData.isRifleUnlocked)
            {
                selectedWeapon = 2;
                SwapWeapon();
                UpdateUi();
            }
            else if (Input.GetKey("4") && (selectedWeapon != 3) && _playerData.isMinigunUnlocked)
            {
                selectedWeapon = 3;
                SwapWeapon();
                UpdateUi();
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
