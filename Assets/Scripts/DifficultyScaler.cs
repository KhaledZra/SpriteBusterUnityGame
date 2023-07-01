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

    public void ApplyDifficultyModifier(int gameTimeInMinutes)
    {
        if (gameTimeInMinutes == 1) // minute 3
        {
            enemyComponent.chaseSpeed = 3f;
        }
        else if (gameTimeInMinutes == 2) // minute 6
        {
            enemyHealthComponent.Heal(1); // todo change later to set hp maybe

        }
        else if (gameTimeInMinutes == 3) // minute 10
        {
            enemyComponent.chaseSpeed = 4f;
        }
        else if (gameTimeInMinutes == 4) // minute 13
        {
            enemyHealthComponent.Heal(1); // todo change later to set hp maybe
        }
        else if (gameTimeInMinutes == 5) // minute 16
        {
            enemyComponent.chaseSpeed = 5f;
        }
    }
}
