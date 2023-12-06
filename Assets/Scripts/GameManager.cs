using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject playerPrefab1;
    public GameObject playerPrefab2;
    public GameObject playerPrefab3;
    public GameObject playerPrefab4;
    public GameObject playerPrefab5;

    public Text livesText;
    public Text playTimeText;

    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;
    public GameObject bossPrefab;
    public GameObject BossBorderBullet;

    [Header("�����")]
    public GameObject LoseReTry;
    [SerializeField] private GameObject WinReTry;
    private GameObject winReTryObj;
    private GameObject loseReTryObj;

    private float enemySpawnTimer = 0f;
    private float enemy2SpawnTimer = 0f;
    private float spawnInterval = 2f; 


    private float startTime; 
    private float elapsedTime; 

    public float currentMinutes;
    public float currentSeconds;


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
        startTime = Time.time; // ���� ���۽ð� �ʱ�ȭ
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
        elapsedTime = Time.time - startTime;

        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        currentMinutes = minutes;
        currentSeconds = seconds;
    playTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (minutes >= 0 && minutes < 1)
        {
            enemySpawnTimer += Time.deltaTime;
            enemy2SpawnTimer += Time.deltaTime;

            if (enemySpawnTimer >= spawnInterval)
            {
                Instantiate(enemyPrefab);
                enemySpawnTimer = 0f;  // Ÿ�̸� �ʱ�ȭ
            }

            if (seconds >= 30 && enemy2SpawnTimer >= spawnInterval)
            {
                Instantiate(enemy2Prefab);
                enemy2SpawnTimer = 0f;  // Ÿ�̸� �ʱ�ȭ
            }
        }
        if (minutes >= 1 && checkBoss == false)
        {
            ChangePlayerPosition();
            Instantiate(BossBorderBullet);
            Invoke("InstantiateBoss", 3f);
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

    private void InstantiateBoss()
    {
        Instantiate(bossPrefab);
        
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
    // �÷��̾��� ��ġ�� �����ϴ� �޼���
    public void ChangePlayerPosition()
    {
        // "Player" �±װ� �ִ� GameObject�� ã���ϴ�
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // player GameObject�� �����ϴ��� Ȯ���մϴ�
        if (player != null)
        {
            // player�� ��ġ�� (0, 0, ���� z)�� �����մϴ�
            player.transform.position = new Vector3(0, 0, player.transform.position.z);
        }
        else
        {
            Debug.LogError("Player ��ü�� ã�� �� �����ϴ�!");
        }
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
    }
    void Lose()
    {
        loseReTryObj.SetActive(true);
        Time.timeScale = 0.1f;
    }

}
