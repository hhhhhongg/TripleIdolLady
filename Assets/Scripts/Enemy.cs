using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _hp;
    private float _damage = 0f;
    private Transform _player;
    private SpriteRenderer _spriteRenderer;
    public int type;
    public float speed = 5f;

    void Start()
    {
        // ������ Ÿ���� 1�϶� ü�� 12f, ���ǵ� 2f
        if (type == 1)
        {
            _hp = 12f;
            speed = 2f;
        }
        // ������ Ÿ���� 2�϶� ü�� 24f, ���ǵ� 1f
        else if (type == 2)
        {
            _hp = 24f;
            speed = 1f;
        }
        // �÷��̾� ������Ʈ�� ã�Ƽ� ������ �Ҵ�
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found in children of Enemy object!");
        }

        // ������ ��ǥ ��������
        SpawnOutsideScreen();
    }

    void Update()
    {
        Vector3 direction = (_player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x > _player.position.x)
        {
            FlipSprite(true);
        }
        else
        {
            FlipSprite(false);
        }
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
            TakeDamage(collider, 4);
        }
        else if (collider.gameObject.tag == "Bullet3")
        {
            TakeDamage(collider, 12);            
        }

        if (collider.gameObject.tag == ("Player"))
        {

            // �� ������Ʈ �ı�
            Destroy(gameObject);
        }
    }
    private void TakeDamage(Collider2D collider, float _bulletDamage)
    {
        if (type == 1)
        {
            if (_damage < _hp)
            {
                _damage += _bulletDamage;
                float num = _damage / _hp;
                Destroy(collider.gameObject);
                gameObject.transform.Find("Enemy1Sprite/Canvas/Front").transform.localScale = new Vector3(num, 1.0f, 1.0f);
                if (num == 1)
                {
                    Destroy(gameObject);
                }
            }            
        }
        else if (type == 2)
        {
            if (_damage < _hp)
            {
                _damage += _bulletDamage;
                float num = _damage / _hp;
                Destroy(collider.gameObject);
                gameObject.transform.Find("Enemy2Sprite/Canvas/Front").transform.localScale = new Vector3(num, 1.0f, 1.0f);
                if (num == 1)
                {
                    Destroy(gameObject);
                }
            }
            
        }
    }

    void SpawnOutsideScreen()
    {
        // ī�޶��� ���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // ȭ���� ���ο� ���� ũ�⸦ ������
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // ������ ������ ����
        float randomDirection = Random.Range(0f, 360f);

        // ������ ��ġ�� ȭ�� �ٱ����� ����
        float radius = Mathf.Sqrt(Mathf.Pow(screenWidth * 0.5f, 2) + Mathf.Pow(screenHeight * 0.5f, 2)) + 5f;
        float x = Mathf.Cos(randomDirection * Mathf.Deg2Rad) * radius + screenWidth * 0.5f;
        float y = Mathf.Sin(randomDirection * Mathf.Deg2Rad) * radius + screenHeight * 0.5f;

        // ��ũ�� ��ǥ�� �ٽ� ���� ��ǥ�� ��ȯ
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(x, y, screenPos.z));
        transform.position = new Vector3(spawnPosition.x, spawnPosition.y, 0f);
    }

    private void FlipSprite(bool isFacingLeft)
    {
        // ��������Ʈ�� �������ϴ�.
        _spriteRenderer.flipX = isFacingLeft;
    }
}
