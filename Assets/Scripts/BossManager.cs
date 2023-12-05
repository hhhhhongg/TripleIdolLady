using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossManager : MonoBehaviour
{
    public string[] enemyObjs;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public ObjectManager objectManager;

    private void Awake()
    {
        enemyObjs = new string[] { "EnemyM" };
    }

    private void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 1.0f);
            curSpawnDelay = 0;
        }
    }
    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 1);
        int ranPoint = Random.Range(0, 10);
        GameObject enemy = objectManager.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPoints[ranPoint].position;

    }
}
