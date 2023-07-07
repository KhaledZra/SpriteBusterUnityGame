using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarHandler : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }
}
