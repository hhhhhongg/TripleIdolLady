using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed = 5.0f;
    public float lifeTime = 5.0f;
    
    void Start()
    {
        // 시간이 지나면 오브젝트 삭제
        Destroy(gameObject, lifeTime);
    }
    
    void Update()
    {
        // x값에 1을 더해준다. 업데이트 메서드에 넣어서 반복 실행
        transform.Translate(Vector2.right.normalized * speed * Time.deltaTime);
    }
}
