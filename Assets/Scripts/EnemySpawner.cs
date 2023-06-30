using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPreFab;
    [SerializeField] private Transform PlayerLocation;
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private BoxCollider2D boundryObject;
    [SerializeField] private BoxCollider2D playerSafetyBoundry;
    
    private float _randomX;
    private float _randomY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(spawnRate, EnemyPreFab));
    }

    private IEnumerator SpawnEnemy(float spawnInterval, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnInterval);

        RandomizeSpawnPointUntilSafe();
        
        GameObject newEnemy = Instantiate(
            enemy, 
            new Vector3(_randomX, _randomY, 0),
            Quaternion.identity);
        
        newEnemy.SetActive(true);
        newEnemy.GetComponent<EnemyHandler>().chaseTarget = PlayerLocation;
        StartCoroutine(SpawnEnemy(spawnInterval, enemy));
    }

    private void RandomizeSpawnPointUntilSafe()
    {
        bool isSafeToSpawn = false;
        
        do
        {
            _randomX = Random.Range(boundryObject.bounds.min.x, boundryObject.bounds.max.x);
            _randomY = Random.Range(boundryObject.bounds.min.y, boundryObject.bounds.max.y);

            if (!IsValueBetweenRange(_randomX,
                    playerSafetyBoundry.bounds.min.x,
                    playerSafetyBoundry.bounds.max.x))
            {
                if (!IsValueBetweenRange(
                        _randomY,
                        playerSafetyBoundry.bounds.min.y,
                        playerSafetyBoundry.bounds.max.y))
                {
                    isSafeToSpawn = true;
                }
            }
        } while (!isSafeToSpawn);
    }
    
    private bool IsValueBetweenRange(float value, float min, float max) 
        => value >= min && value <= max;
}
