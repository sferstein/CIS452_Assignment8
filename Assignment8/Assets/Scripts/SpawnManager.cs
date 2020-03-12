using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * SpawnManager.cs
 * Assignment 8
 * This manages the enemies that spawn.
 */

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private GameManager gameManager;
    private float spawnPosZ = 5;
    private float delay = 0.5f;
    private float spawnRangeX = 6;
    private float spawnInterval = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", delay, spawnInterval);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void spawnEnemy()
    {
        if (gameManager.isGameActive)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int asteroidIndex = Random.Range(0, enemyPrefab.Length);

            Instantiate(enemyPrefab[asteroidIndex], spawnPos,
                enemyPrefab[asteroidIndex].transform.rotation);
        }
    }
}
