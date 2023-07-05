using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int maxHealthPoints = 1;
    [SerializeField] private int healthPoints = 1;
    [SerializeField] private bool isPlayer = false;
    
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
        GameObject.FindWithTag("HealthUI")
            .GetComponent<HealthUiHandler>()
            .UpdateHealthUi();
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
                GameObject.FindWithTag("HealthUI")
                    .GetComponent<HealthUiHandler>()
                    .UpdateHealthUi();
            }
            return;
        }
        
        // Death mechanics
        if (isPlayer)
        {
            // todo change to better system later (playerDeathHandler)
            SceneManager.LoadScene("Scenes/MainMenu");
        }
        else if (gameObject.CompareTag("Enemy")) // most likely enemy, but to be safe
        {
            KillCountHandler killCountScript = GameObject.FindWithTag("KillCount").GetComponent<KillCountHandler>();
            killCountScript.AddKill();
            Destroy(gameObject);
        }
    }
}
