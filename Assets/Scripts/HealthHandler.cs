using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int healthPoints = 1;
    [SerializeField] private bool isPlayer = false;
    
    public int GetHealthPoints() => healthPoints;

    public void Heal(int amount)
    {
        // todo set cap? maybe 3
        healthPoints += amount;
        GameObject.FindWithTag("HealthUI")
            .GetComponent<HealthUiHandler>()
            .UpdateHealthUi();
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
                GameObject.FindWithTag("HealthUI").GetComponent<HealthUiHandler>().UpdateHealthUi();
            }
            return;
        }
        
        // Death mechanics
        if (isPlayer)
        {
            // todo change to better system later (playerDeathHandler)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (gameObject.CompareTag("Enemy")) // most likely enemy, but to be safe
        {
            var killCountScript = GameObject.FindWithTag("KillCount").GetComponent<KillCountHandler>();
            killCountScript.AddKill();
            Destroy(gameObject);
        }
    }
}
