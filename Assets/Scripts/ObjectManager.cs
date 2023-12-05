using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject HeadBossPrefab;

    public GameObject BossBulletAPrefab;
    public GameObject BossBulletBPrefab;

    GameObject[] HeadBoss;

    GameObject[] BossBulletA;
    GameObject[] BossBulletB;

    GameObject[] targetPool;

    private void Awake()
    {
        HeadBoss = new GameObject[1];

        BossBulletA = new GameObject[100];
        BossBulletB = new GameObject[100];
        Generate();
    }

    void Generate()
    {
        for (int index = 0; index <= HeadBoss.Length; index++)
        {
            //HeadBoss[index] = Instantiate(HeadBossPrefab);
            //HeadBoss[index].SetActive(false);
        }

        //º¸½º ÃÑ¾Ë
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
            case "HeadBoss":
                targetPool = HeadBoss;
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
    public GameObject[] GetPool(string type)
    {
        switch (type)
        {
            case "HeadBoss":
                targetPool = HeadBoss;
                break;
            case "BossBulletA":
                targetPool = BossBulletA;
                break;
            case "BossBulletB":
                targetPool = BossBulletB;
                break;
        }
        return targetPool;
    }
  
}
