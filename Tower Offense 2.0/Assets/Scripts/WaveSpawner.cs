using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform waterEnemyLeftPrefab;
    public Transform waterEnemyCenterPrefab;
    public Transform waterEnemyRightPrefab;

    public Transform windEnemyLeftPrefab;
    public Transform windEnemyCenterPrefab;
    public Transform windEnemyRightPrefab;

    public Transform earthEnemyLeftPrefab;
    public Transform earthEnemyCenterPrefab;
    public Transform earthEnemyRightPrefab;

    public Transform enemySpawnPoint;

    public float timeBetweenWaves;
    public float timeBetweenEnemies;
    private float countdown = 2f;

    //private int waveNumber = 1;

    public string enemyType;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Spawn");

        //waveNumber++;

        for (int i = 0; i < 3; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    void SpawnEnemy()
    {
        string[] enemyTypes = new string[] { "WaterCenter", "WaterLeft", "WaterRight", 
                                            "WindCenter", "WindLeft", "WindRight",
                                            "EarthCenter", "EarthLeft", "EarthRight"};
        System.Random randomType = new System.Random();
        int useType = randomType.Next(enemyTypes.Length);
        enemyType = enemyTypes[useType];


        if (enemyType == "WaterCenter")
        {
            Instantiate(waterEnemyCenterPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        }

        else if (enemyType == "WaterLeft")
        {
            Instantiate(waterEnemyLeftPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        }

        else if (enemyType == "WaterRight")
        {
            Instantiate(waterEnemyRightPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        }

        else if (enemyType == "WindCenter")
        {
            Instantiate(windEnemyCenterPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        }

        else if (enemyType == "WindLeft")
        {
            Instantiate(windEnemyLeftPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        }

        else if (enemyType == "WindRight")
        {
            Instantiate(windEnemyRightPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        }

        else if (enemyType == "EarthCenter")
        {
            Instantiate(earthEnemyCenterPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        }

        else if (enemyType == "EarthLeft")
        {
            Instantiate(earthEnemyLeftPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        }

        else if (enemyType == "EarthRight")
        {
            Instantiate(earthEnemyRightPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        }
    }
}
