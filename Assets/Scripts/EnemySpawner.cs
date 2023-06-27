using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPreFab;
    [SerializeField] private Transform PlayerLocation;
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private BoxCollider2D boundryObject;
    
    private float _randomX;
    private float _randomY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(spawnRate, EnemyPreFab));
    }

    private IEnumerator SpawnEnemy(float spawnInterval, GameObject enemy)
    {
        // todo fix boundry to map, and new boundry around player
        Debug.Log(boundryObject.bounds.max);
        Debug.Log(boundryObject.bounds.min);
        // todo change range system
        yield return new WaitForSeconds(spawnInterval);

        _randomX = Random.Range(-18f, 18f);
        _randomY = Random.Range(-10f, 10f);
        GameObject newEnemy = Instantiate(
            enemy, 
            new Vector3(_randomX, _randomY, 0),
            Quaternion.identity);
        
        newEnemy.GetComponent<EnemyChase>().chaseTarget = PlayerLocation;
        StartCoroutine(SpawnEnemy(spawnInterval, enemy));
    }
}
