using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _hp;
    private float _damage = 0f;
    public int type;

    void Start()
    {
        // 랜덤한 좌표 가져오기
        float x = Random.Range(-8f, 8f);
        float y = 10f;

        // 몬스터의 타입이 1일때 체력 10f
        if (type == 1)
        {
            _hp = 10f;
        }
        // 몬스터의 타입이 2일때 체력 20f
        else if (type == 2)
        {
            _hp = 20f;
        }
        transform.position = new Vector3(x, y, 0);
    }

    void Update()
    {
        transform.position += new Vector3(0, -0.05f, 0);
    }

    // Bullet과 Enemy가 부딪혔을때 발생하는 일들
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            if (type == 1)
            {
                if (_damage < _hp)
                {
                    _damage += 2f;
                    Destroy(collider.gameObject);
                    gameObject.transform.Find("Enemy1Sprite/Canvas/Front").transform.localScale = new Vector3(_damage / _hp, 1.0f, 1.0f);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else if (type == 2)
            {
                if (_damage < _hp)
                {
                    _damage += 2f;
                    Destroy(collider.gameObject);
                    gameObject.transform.Find("Enemy2Sprite/Canvas/Front").transform.localScale = new Vector3(_damage / _hp, 1.0f, 1.0f);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            
        }
    }
}
