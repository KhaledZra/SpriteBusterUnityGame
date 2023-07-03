using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSafeSpawn : MonoBehaviour
{
    [SerializeField] private BoxCollider2D playerSafetyBoundry;
    [SerializeField] private BoxCollider2D boundryObject;
    
    public Vector2 RandomizeSpawnPointUntilSafe()
    {
        Vector2 safePos = Vector2.zero;
        bool isSafeToSpawn = false;
        
        do
        {
            safePos.x = Random.Range(boundryObject.bounds.min.x, boundryObject.bounds.max.x);
            safePos.y = Random.Range(boundryObject.bounds.min.y, boundryObject.bounds.max.y);

            if (!IsValueBetweenRange(safePos.x,
                    playerSafetyBoundry.bounds.min.x,
                    playerSafetyBoundry.bounds.max.x))
            {
                if (!IsValueBetweenRange(
                        safePos.y,
                        playerSafetyBoundry.bounds.min.y,
                        playerSafetyBoundry.bounds.max.y))
                {
                    isSafeToSpawn = true;
                }
            }
        } while (!isSafeToSpawn);

        return safePos;
    }
    
    private bool IsValueBetweenRange(float value, float min, float max) 
        => value >= min && value <= max;
}
