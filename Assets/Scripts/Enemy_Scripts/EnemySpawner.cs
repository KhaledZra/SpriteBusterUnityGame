using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPreFab;
    [SerializeField] private GameObject bossPreFab;
    [SerializeField] private Transform playerLocation;
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private GenerateSafeSpawn spawnComponent;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBoss(bossPreFab);
        StartCoroutine(SpawnEnemy(spawnRate, enemyPreFab));
    }

    private IEnumerator SpawnEnemy(float spawnInterval, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnInterval);
        Vector2 randomPos = spawnComponent.RandomizeSpawnPointUntilSafe();
        
        GameObject newEnemy = Instantiate(
            enemy, 
            new Vector3(randomPos.x, randomPos.y, 0),
            Quaternion.identity);
        
        newEnemy.SetActive(true);
        newEnemy.GetComponent<EnemyHandler>().chaseTarget = playerLocation;

        StartCoroutine(SpawnEnemy(spawnInterval, enemy));
        
    }

    private void SpawnBoss(GameObject bossObject)
    {
        Vector2 randomPos = spawnComponent.RandomizeSpawnPointUntilSafe();
        
        GameObject newEnemy = Instantiate(
            bossObject,
            new Vector3(randomPos.x, randomPos.y, 0),
            Quaternion.identity);
        
        newEnemy.GetComponent<EnemyHandler>().chaseTarget = playerLocation;
    }
}
