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
        // 몬스터의 타입이 1일때 체력 12f, 스피드 2f
        if (type == 1)
        {
            _hp = 12f;
            speed = 2f;
        }
        // 몬스터의 타입이 2일때 체력 24f, 스피드 1f
        else if (type == 2)
        {
            _hp = 24f;
            speed = 1f;
        }
        // 플레이어 오브젝트를 찾아서 변수에 할당
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found in children of Enemy object!");
        }

        // 랜덤한 좌표 가져오기
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

    // Bullet과 Enemy가 부딪혔을때 발생하는 일들
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

            // 적 오브젝트 파괴
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
        // 카메라의 월드 좌표를 스크린 좌표로 변환
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // 화면의 가로와 세로 크기를 가져옴
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // 랜덤한 방향을 결정
        float randomDirection = Random.Range(0f, 360f);

        // 랜덤한 위치를 화면 바깥으로 설정
        float radius = Mathf.Sqrt(Mathf.Pow(screenWidth * 0.5f, 2) + Mathf.Pow(screenHeight * 0.5f, 2)) + 5f;
        float x = Mathf.Cos(randomDirection * Mathf.Deg2Rad) * radius + screenWidth * 0.5f;
        float y = Mathf.Sin(randomDirection * Mathf.Deg2Rad) * radius + screenHeight * 0.5f;

        // 스크린 좌표를 다시 월드 좌표로 변환
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(x, y, screenPos.z));
        transform.position = new Vector3(spawnPosition.x, spawnPosition.y, 0f);
    }

    private void FlipSprite(bool isFacingLeft)
    {
        // 스프라이트를 뒤집습니다.
        _spriteRenderer.flipX = isFacingLeft;
    }
}
