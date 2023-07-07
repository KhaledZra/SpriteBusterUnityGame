using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EquippedUiHandler : MonoBehaviour
{
    [SerializeField] private List<Sprite> equipmentSprites;
    [SerializeField] private Image equipmentImage;
    [SerializeField] private TextMeshProUGUI equipmentText;

    private void Start()
    {
        equipmentText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void UpdateEquipmentUi(string weaponName, int weaponOrder)
    {
        equipmentText.text = weaponName;
        equipmentImage.sprite = equipmentSprites[weaponOrder];
    }
}
