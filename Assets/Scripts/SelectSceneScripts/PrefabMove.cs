using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    private Vector3 moveDirection;

    public void setup(Vector3 direction)
    {
        moveDirection = direction;
    }
    private void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
