using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int maxHealthPoints = 1;
    [SerializeField] private int healthPoints = 1;
    [SerializeField] private bool isBoss = false;
    [SerializeField] private HpBarHandler healthBar;
    [SerializeField] private JsonPlayerDataHandler playerDataHandler;
    
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private HealthUiHandler healthUiHandler;

    private bool _hasHealthBar = false;

    private void Start()
    {
        if (healthBar != null) _hasHealthBar = true;
        if (healthUiHandler != null) healthUiHandler.UpdateHealthUi(maxHealthPoints);
    }

    public int GetHealthPoints() => healthPoints;

    public void Heal(int amount)
    {
        // check if healing is needed
        if (healthPoints == maxHealthPoints)
        {
            return;
        }
        
        healthPoints += amount;
        // Check if overhealed
        if (healthPoints > maxHealthPoints)
        {
            healthPoints = maxHealthPoints;
        }
        if (_hasHealthBar)
        {
            healthBar.UpdateHealthBar(healthPoints, maxHealthPoints);
        }
        healthUiHandler.UpdateHealthUi(healthPoints);
    }

    public void SetMaxHealthPoints(int newMaxValue)
    {
        maxHealthPoints = newMaxValue;
        healthPoints = maxHealthPoints;
    }

    public void TakeDamage(int amount)
    {
        healthPoints -= amount;
        HandleDamageResult();
    }

    private void HandleDamageResult()
    {
        // If still alive mechanics
        if (healthPoints >= 1)
        {
            if (isPlayer)
            {
                healthUiHandler.UpdateHealthUi(healthPoints);
            }

            if (_hasHealthBar)
            {
                healthBar.UpdateHealthBar(healthPoints, maxHealthPoints);
            }
            return;
        }
        
        // Death mechanics
        KillCountHandler killCountScript = GameObject.FindWithTag("KillCount").GetComponent<KillCountHandler>();
        if (isPlayer)
        {
            playerDataHandler.SavePlayerDataToJson(killCountScript.GetKillCount());
            SceneManager.LoadScene("LoseScene");
        }
        else if (isBoss)
        {
            playerDataHandler.SavePlayerDataToJson(killCountScript.GetKillCount());
            SceneManager.LoadScene("WinScene");
        }
        else if (gameObject.CompareTag("Enemy")) // most likely enemy, but to be safe
        {
            killCountScript.AddKill();
            Destroy(gameObject);
        }
    }
}
