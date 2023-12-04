using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject playTime;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;
    public GameObject bossPrefab;
    public GameObject enemyTypeTime;

    private float enemySpawnTimer = 0f;
    private float enemy2SpawnTimer = 0f;
    private float spawnInterval = 5f;  // n�� ���� (��: 5��)

    int currentMinutes;
    int currentSeconds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //------------------------------------------------------------------------
    
    private void Start()
    {
        InstantiatePlayer();
        
    }

    
    void Update()
    {
        currentMinutes = enemyTypeTime.GetComponent<PlayTime>().GetMinutes();
        currentSeconds = enemyTypeTime.GetComponent<PlayTime>().GetSeconds();

        if (currentMinutes >= 0 && currentMinutes < 1)
        {
            enemySpawnTimer += Time.deltaTime;
            enemy2SpawnTimer += Time.deltaTime;

            if (enemySpawnTimer >= spawnInterval)
            {
                Instantiate(enemyPrefab);
                enemySpawnTimer = 0f;  // Ÿ�̸� �ʱ�ȭ
            }

            if (currentSeconds >= 30 && enemy2SpawnTimer >= spawnInterval)
            {
                Instantiate(enemy2Prefab);
                enemy2SpawnTimer = 0f;  // Ÿ�̸� �ʱ�ȭ
            }
        }
        else if (currentMinutes >= 1)
        {
            

            if (currentSeconds == 0)
            {
                Destroy(enemyPrefab);
                Destroy(enemy2Prefab);
                Instantiate(bossPrefab);
            }
        }
    }

    private void InstantiatePlayer()
    {
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
    
   
}
