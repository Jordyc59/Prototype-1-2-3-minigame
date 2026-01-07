using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public float spawnRange = 20f;
    public float spawnInterval = 2f;
   

    void Start()
    {
        InvokeRepeating("SpawnItem", 1f, spawnInterval);
        
    }

    void SpawnItem()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            1f,
            Random.Range(-spawnRange, spawnRange)
        );

        GameObject item = Instantiate(itemPrefab, randomPos, Quaternion.identity);
        Destroy(item, 4f);
    }

    void update()

      {
            Destroy(gameObject);
        }
}
