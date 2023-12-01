using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    /*private void OnMove(InputValue value) // w  a  s d
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        animator.SetBool("Iswalk", moveInput != Vector2.zero);
    }*/
}
