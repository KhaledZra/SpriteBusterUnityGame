using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Serialization;

public class DifficultyScaler : MonoBehaviour
{
    [SerializeField] private EnemyHandler enemyComponent;
    [SerializeField] private HealthHandler enemyHealthComponent;
    [SerializeField] private SpriteRenderer enemyRenderComponent;

    public void ApplyDifficultyModifier(int gameTimeInMinutes)
    {
        if (gameTimeInMinutes == 1) // minute 3
        {
            enemyComponent.chaseSpeed = 3f;
            enemyRenderComponent.color = Color.yellow;
        }
        else if (gameTimeInMinutes == 2) // minute 6
        {
            enemyHealthComponent.SetMaxHealthPoints(2);
            enemyRenderComponent.color = Color.blue;
        }
        else if (gameTimeInMinutes == 3) // minute 10
        {
            enemyComponent.chaseSpeed = 4f;
            enemyRenderComponent.color = Color.cyan;
        }
        else if (gameTimeInMinutes == 4) // minute 13
        {
            enemyHealthComponent.SetMaxHealthPoints(3);
            enemyRenderComponent.color = Color.white;
        }
        else if (gameTimeInMinutes == 5) // minute 16
        {
            enemyComponent.chaseSpeed = 5f;
            enemyRenderComponent.color = Color.magenta;
        }
    }
}
