using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed = 5.0f;
    public float lifeTime = 5.0f;
    
    void Start()
    {
        // �ð��� ������ ������Ʈ ����
        Destroy(gameObject, lifeTime);
    }
    
    void Update()
    {
        // x���� 1�� �����ش�. ������Ʈ �޼��忡 �־ �ݺ� ����
        transform.Translate(Vector2.right.normalized * speed * Time.deltaTime);
    }
}
