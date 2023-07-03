using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GenerateSafeSpawn spawnComponent;
    [SerializeField] private List<GameObject> pickupObjects;

    private float _randomX;
    private float _randomY;

    private void Start()
    {
        StartCoroutine(GenerateSpawn());
    }

    private void SpawnRandomPickup()
    {
        if (pickupObjects.Count == 0)
        {
            Debug.Log("Empty pickup spawn list");
            return;
        }

        Vector3 randomSpawnPos = spawnComponent.RandomizeSpawnPointUntilSafe();

        GameObject newGameObject;
        if (pickupObjects.Count == 1)
        {
            newGameObject = Instantiate(pickupObjects.First(), randomSpawnPos, quaternion.identity);
        }
        else
        {
            newGameObject = Instantiate(pickupObjects[Random.Range(0, pickupObjects.Count)], 
                randomSpawnPos, quaternion.identity);
        }
        newGameObject.SetActive(true);
    }

    IEnumerator GenerateSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));
            SpawnRandomPickup();
        }
    }
}
