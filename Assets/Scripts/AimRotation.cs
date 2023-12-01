using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _armRenderer;
    [SerializeField] private Transform _armPivot;

    [SerializeField] private SpriteRenderer _playerRenderer;    

    private PlayerController _controller;
    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }
    
    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }
    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        _playerRenderer.flipX = _armRenderer.flipY;

        _armPivot.rotation = Quaternion.Euler(0, 0, rotZ);        
    }    
}
