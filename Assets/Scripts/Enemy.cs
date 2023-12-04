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
        // ������ ��ǥ ��������
        float x = Random.Range(-4f, 4f);
        float y = 0f;

        // ������ Ÿ���� 1�϶� ü�� 10f
        if (type == 1)
        {
            _hp = 12f;
        }
        // ������ Ÿ���� 2�϶� ü�� 20f
        else if (type == 2)
        {
            _hp = 24f;
        }
        transform.position = new Vector3(x, y, 0);
    }

    void Update()
    {
        // transform.position += new Vector3(0, -0.05f, 0);
    }

    // Bullet�� Enemy�� �ε������� �߻��ϴ� �ϵ�
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet1")
        {
            TakeDamage(collider, 2);
        }
        else if (collider.gameObject.tag == "Bullet2")
        {
            TakeDamage(collider, 3);
        }
        else if (collider.gameObject.tag == "Bullet3")
        {
            TakeDamage(collider, 4);
        }
    }
    private void TakeDamage(Collider2D collider, float _bulletDamage)
    {
        if (type == 1)
        {
            if (_damage < _hp)
            {
                _damage += _bulletDamage;
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
                _damage += _bulletDamage;
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
