using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;


public class Bullet : MonoBehaviour
{    
    void Start()
    {
        
    }
    void Update()
    {
        // 마우스 포인터의 벡터 방향 값만 가져와서 적용 시킨다면?
        transform.Translate(new Vector3(1, 1, 0) * Time.deltaTime);
    }
    
}
