using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEnemyPos : MonoBehaviour
{

    public GameObject spawnManager;
    public GameObject enemy;
    private SpawnManager spawnmanager;

    // Start is called before the first frame update
    void Start()
    {
        spawnmanager = spawnManager.GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnmanager.enemyPrefab.transform.position.y < -10)
        {
            spawnmanager.Start();
        }
    }
}
