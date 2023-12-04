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
        // ���콺 �������� ��ǥ�� ��ũ�� �������� ���� ��´�.
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ��ũ�� �߾��� �������� ���Ͱ��� �����Ƿ� ��ü�� ���Ͱ��� ���༭ ������ ��ü�� ����� �ش�.
        Vector2 newAim = (direction - (Vector2)transform.position).normalized;
        // ���콺 �����ͱ����� ���� ���͸� ��´�.
        float rotZ = Mathf.Atan2(newAim.y, newAim.x) * Mathf.Rad2Deg;
        // 90���� �Ѿ�� �Ҹ��� �̹����� �ø��� �ش�.
        _bulletRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        // ����(�������� �Ҹ�, ���� ����, �����̼� ���� ���콺 �����ͱ����� ���� ���͸� �־��ش�.
        Instantiate(_prefabBullet, _bulletSpawnPosition.position, Quaternion.AngleAxis(rotZ, Vector3.forward));
        
    }
    
}
