using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject playTime;
    public GameObject playerPrefab1;
    public GameObject playerPrefab2;
    public GameObject playerPrefab3;
    public GameObject playerPrefab4;
    public GameObject playerPrefab5;

    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;
    public GameObject bossPrefab;
    public GameObject enemyTypeTime;

    private float enemySpawnTimer = 0f;
    private float enemy2SpawnTimer = 0f;
    private float spawnInterval = 5f;  // n초 간격 (예: 5초)

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
                enemySpawnTimer = 0f;  // 타이머 초기화
            }

            if (currentSeconds >= 30 && enemy2SpawnTimer >= spawnInterval)
            {
                Instantiate(enemy2Prefab);
                enemy2SpawnTimer = 0f;  // 타이머 초기화
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
        int playerSelection = PlayerPrefs.GetInt("PlayerSelect");

        GameObject playerPrefab = null;

        switch (playerSelection)
        {
            case 1:
                playerPrefab = playerPrefab1; 
                break;
            case 2:
                playerPrefab = playerPrefab2;
                break;
            case 3:
                playerPrefab = playerPrefab3;
                break;
            case 4:
                playerPrefab = playerPrefab4;
                break;
            case 5:
                playerPrefab = playerPrefab5;
                break;
            default:
                Debug.LogError("플레이어 선택에 실패하였습니다.");
                return;
        }
    }
    
   
}
