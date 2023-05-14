using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    private float enemyY;
    private float powerupY;

    // Start is called before the first frame update
    public void Start()
    {
        enemyY = enemyPrefab.transform.position.y;
        powerupY = powerupPrefab.transform.position.y;

        Instantiate(enemyPrefab, GenerateSpawnPosition(enemyY), enemyPrefab.transform.rotation);
        Instantiate(powerupPrefab, GenerateSpawnPosition(powerupY), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    private Vector3 GenerateSpawnPosition(float posY)
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, posY, spawnPosZ);

        return randomPos;
    }
}
