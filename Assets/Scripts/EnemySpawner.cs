using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPreFab;
    [SerializeField] private Transform PlayerLocation;
    [SerializeField] private float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(spawnRate, EnemyPreFab));
    }

    private IEnumerator SpawnEnemy(float spawnInterval, GameObject enemy)
    {
        // todo change range system
        yield return new WaitForSeconds(spawnInterval);
        GameObject newEnemy = Instantiate(
            enemy, 
            new Vector3(Random.Range(-18f, 18f), Random.Range(-10f, 10f), 0),
            Quaternion.identity);
        newEnemy.GetComponent<EnemyChase>().chaseTarget = PlayerLocation;
        StartCoroutine(SpawnEnemy(spawnInterval, enemy));
    }
}
