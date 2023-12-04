using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    private PlayerController _controller;

    [SerializeField] private Transform _bulletSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public GameObject _prefabBullet;
    public SpriteRenderer _bulletRenderer;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }

    void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;        
    }
    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        // 마우스 포인터의 좌표를 스크린 기준으로 값을 얻는다.
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 스크린 중앙을 기준으로 벡터값이 나오므로 객체의 벡터값을 빼줘서 기준을 객체로 만들어 준다.
        Vector2 newAim = (direction - (Vector2)transform.position).normalized;
        // 마우스 포인터까지의 방향 벡터를 얻는다.
        float rotZ = Mathf.Atan2(newAim.y, newAim.x) * Mathf.Rad2Deg;
        // 90도를 넘어가면 불릿의 이미지를 플립해 준다.
        _bulletRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        // 생성(프리펩의 불릿, 생성 지점, 로테이션 값에 마우스 포인터까지의 방향 벡터를 넣어준다.
        Instantiate(_prefabBullet, _bulletSpawnPosition.position, Quaternion.AngleAxis(rotZ, Vector3.forward));
        
    }
    
}
