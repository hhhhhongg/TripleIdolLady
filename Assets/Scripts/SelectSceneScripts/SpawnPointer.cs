using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointer : MonoBehaviour
{
    [SerializeField]
    private int maxcount = 20;  //��������
    [SerializeField]
    private GameObject[] prefabArray;   //���
    [SerializeField]
    private Transform[] spawnPointArray;
    private float timer;            //�ð�üũ
    [SerializeField]
    private float waittime = 3f;  //�����ֱ�
    private int currentcount = 0;
    private Vector3 moveDirection;

    private void Awake()
    {
        timer = 0.0f;

        int prefabIndex = Random.Range(0, prefabArray.Length);    //���
        int spawnIndex = Random.Range(0, spawnPointArray.Length); //������ġ
        Vector3 position = spawnPointArray[spawnIndex].position;  //��ġ

    }

    void Update()
    {
        if (currentcount + 1 > maxcount) //��������
        {
            return;
        }
        int prefabIndex = Random.Range(0, prefabArray.Length);        //���
        int spawnIndex = Random.Range(0, spawnPointArray.Length);     //������ġ
        Vector3 position = spawnPointArray[spawnIndex].position;

        timer += Time.deltaTime;    //�ð� üũ
        if (timer > waittime)
        {
            GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);
            moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);

            clone.GetComponent<PrefabMove>().setup(moveDirection);
            currentcount++;
            timer = 0;  //�ð� �ʱ�ȭ
            Destroy(clone, 20); //X�� �� ����
        }

    }
}