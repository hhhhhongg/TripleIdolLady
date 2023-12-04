using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    [SerializeField] private float _cooltime = 0.2f;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    protected virtual void Update()
    {
        HandleAttackDelay();        
    }
    private void HandleAttackDelay()
    {
        if (_timeSinceLastAttack <= _cooltime)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastAttack > _cooltime)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
