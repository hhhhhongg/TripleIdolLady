using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerAnimation : MonoBehaviour
{
    PlayerInputController _controller;
    
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _controller = GetComponent<PlayerInputController>();
    }
    void Start()
    {
        _controller.OnMoveEvent += AnimState;
    }
    void AnimState(Vector2 dir)
    {
        _animator.SetBool("isWalk", dir.magnitude > 0);
    }
}
