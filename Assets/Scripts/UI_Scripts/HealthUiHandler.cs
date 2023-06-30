using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUiHandler : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;

    private TextMeshProUGUI _healthText;
    private int _currentHealth;

    private void Start()
    {
        _healthText = gameObject.GetComponent<TextMeshProUGUI>();
        UpdateHealthUi();
    }

    public void UpdateHealthUi()
    {
        _currentHealth = playerObject.GetComponent<HealthHandler>().GetHealthPoints();
        _healthText.text = "Health: " + _currentHealth;
    }
}
