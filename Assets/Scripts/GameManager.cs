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

    [Header("재시작")]
    public GameObject LoseReTry;
    [SerializeField] private GameObject WinReTry;
    private GameObject winReTryObj;
    private GameObject loseReTryObj;

    private float enemySpawnTimer = 0f;
    private float enemy2SpawnTimer = 0f;
    private float spawnInterval = 5f;  // n초 간격 (예: 5초)

    private float startTime; // 게임 시작 시간
    private float elapsedTime; // 경과 시간

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
        startTime = Time.time; // 게임 시작시간 초기화
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

        playTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (minutes >= 0 && minutes < 1)
        {
            enemySpawnTimer += Time.deltaTime;
            enemy2SpawnTimer += Time.deltaTime;

            if (enemySpawnTimer >= spawnInterval)
            {
                Instantiate(enemyPrefab);
                enemySpawnTimer = 0f;  // 타이머 초기화
            }

            if (seconds >= 30 && enemy2SpawnTimer >= spawnInterval)
            {
                Instantiate(enemy2Prefab);
                enemy2SpawnTimer = 0f;  // 타이머 초기화
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
                Debug.LogError("플레이어 선택에 실패하였습니다.");
                return;
        }
        Instantiate(playerPrefab);
    }
    // 플레이어의 위치를 변경하는 메서드
    public void ChangePlayerPosition()
    {
        // "Player" 태그가 있는 GameObject를 찾습니다
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // player GameObject가 존재하는지 확인합니다
        if (player != null)
        {
            // player의 위치를 (0, 0, 현재 z)로 설정합니다
            player.transform.position = new Vector3(0, 0, player.transform.position.z);
        }
        else
        {
            Debug.LogError("Player 객체를 찾을 수 없습니다!");
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
        // 게임 오버 처리
        // 예: 화면에 "게임 오버" 메시지를 표시하거나 다른 처리를 수행
    }
    void Lose()
    {
        loseReTryObj.SetActive(true);
        Time.timeScale = 0.1f;
        // 게임 오버 처리
        // 예: 화면에 "게임 오버" 메시지를 표시하거나 다른 처리를 수행
    }

}
