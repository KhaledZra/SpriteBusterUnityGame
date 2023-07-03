using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPreFab;
    [SerializeField] private Transform PlayerLocation;
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private GenerateSafeSpawn spawnComponent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(spawnRate, EnemyPreFab));
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
        newEnemy.GetComponent<EnemyHandler>().chaseTarget = PlayerLocation;
        StartCoroutine(SpawnEnemy(spawnInterval, enemy));
    }
}
