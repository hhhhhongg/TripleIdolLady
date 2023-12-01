using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject EnemyMPrefab;

    public GameObject BossBulletAPrefab;
    public GameObject BossBulletBPrefab;

    GameObject[] EnemyM;

    GameObject[] BossBulletA;
    GameObject[] BossBulletB;

    GameObject[] targetPool;

    private void Awake()
    {
        EnemyM = new GameObject[10];

        BossBulletA = new GameObject[500];
        BossBulletB = new GameObject[500];

        Generate();
    }

    void Generate()
    {
        //보스 에너미
        for(int index=0; index < EnemyM.Length; index++)
        {
            EnemyM[index] = Instantiate(EnemyMPrefab);
            EnemyM[index].SetActive(false);
        }

        //보스 총알
        for (int index = 0; index < BossBulletA.Length; index++)
        {
            BossBulletA[index] = Instantiate(BossBulletAPrefab);
            BossBulletA[index].SetActive(false);
        }
        for (int index = 0; index < BossBulletB.Length; index++)
        {
            BossBulletB[index] = Instantiate(BossBulletBPrefab);
            BossBulletB[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "EnemyM":
                targetPool = EnemyM;
                break;
            case "BossBulletA":
                targetPool = BossBulletA;
                break;
            case "BossBulletB":
                targetPool = BossBulletB;
                break;
        }
        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }

        }

        return null;
    }
}
