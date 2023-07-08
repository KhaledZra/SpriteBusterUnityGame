using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUiHandler : MonoBehaviour
{
    private TextMeshProUGUI _healthText;

    private void Start()
    {
        _healthText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void UpdateHealthUi(int currentHealth)
    {
        _healthText.text = "Health: " + currentHealth;
    }
}
