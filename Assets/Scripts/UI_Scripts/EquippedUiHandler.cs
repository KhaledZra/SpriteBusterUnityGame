using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquippedUiHandler : MonoBehaviour
{
    [SerializeField] List<Sprite> equipmentSprites;
    [SerializeField] Image equipmentImage;
    
    private TextMeshProUGUI _equipmentText;

    private void Start()
    {
        _equipmentText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void UpdateEquipmentUi(string weaponName, int weaponOrder)
    {
        _equipmentText.text = weaponName;
        equipmentImage.sprite = equipmentSprites[weaponOrder];
    }
}
