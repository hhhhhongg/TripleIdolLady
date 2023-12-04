using UnityEngine;

public class SpawnPointer : MonoBehaviour
{
    [SerializeField]
    private int maxcount = 20;  //개수제한
    [SerializeField]
    private GameObject[] prefabArray;   //모양
    [SerializeField]
    private Transform[] spawnPointArray;
    private float timer;            //시간체크
    [SerializeField]
    private float waittime = 3f;  //스폰주기
    private Vector3 moveDirection;

    private void Awake()
    {
        timer = 0.0f;

        int prefabIndex = Random.Range(0, prefabArray.Length);    //모양
        int spawnIndex = Random.Range(0, spawnPointArray.Length); //스폰위치
        Vector3 position = spawnPointArray[spawnIndex].position;  //위치

    }

    void Update()
    {
        int prefabIndex = Random.Range(0, prefabArray.Length);        //모양
        int spawnIndex = Random.Range(0, spawnPointArray.Length);     //스폰위치
        Vector3 position = spawnPointArray[spawnIndex].position;

        timer += Time.deltaTime;    //시간 체크
        if (timer > waittime)
        {
            GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);
            moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);

            clone.GetComponent<PrefabMove>().setup(moveDirection);
            timer = 0;  //시간 초기화
            Destroy(clone, 5); //X초 뒤 삭제

        }

    }
}
