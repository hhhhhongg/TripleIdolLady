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

    public Text livesText;

    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;
    public GameObject bossPrefab;
    public GameObject enemyTypeTime;

    [Header("�����")]
    public GameObject LoseReTry;
    [SerializeField] private GameObject WinReTry;
    private GameObject winReTryObj;
    private GameObject loseReTryObj;

    private float enemySpawnTimer = 0f;
    private float enemy2SpawnTimer = 0f;
    private float spawnInterval = 5f;  // n�� ���� (��: 5��)

    int currentMinutes;
    int currentSeconds;

    public bool BossIsDead = false;
    bool playerIsDead = false;
    bool checkBoss = false;

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
        Time.timeScale = 1f;

        BossIsDead = false;
        playerIsDead = false;

        winReTryObj = Instantiate(WinReTry);
        loseReTryObj = Instantiate(LoseReTry);

        winReTryObj.SetActive(false);
        loseReTryObj.SetActive(false);

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
        if (currentMinutes >= 0 && checkBoss == false)
        {
            Instantiate(bossPrefab);
            checkBoss = true;
        }
        if (BossIsDead == true)
        {
            Win();
        }
        if (playerIsDead == true)
        {
            Lose();
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
                // Debug.Log(playerPrefab);
            default:
                Debug.LogError("�÷��̾� ���ÿ� �����Ͽ����ϴ�.");
                return;
        }
        Instantiate(playerPrefab);
    }
    
    public void UpdateLives(int lives)
    {
        livesText.text = $"{lives.ToString()}";
        if (lives <= 0)
        {
            playerIsDead = true; 
        }
    }

    void Win()
    {
        winReTryObj.SetActive(true);
        Time.timeScale = 0.1f;
        // ���� ���� ó��
        // ��: ȭ�鿡 "���� ����" �޽����� ǥ���ϰų� �ٸ� ó���� ����
    }
    void Lose()
    {
        loseReTryObj.SetActive(true);
        Time.timeScale = 0.1f;
        // ���� ���� ó��
        // ��: ȭ�鿡 "���� ����" �޽����� ǥ���ϰų� �ٸ� ó���� ����
    }

}
