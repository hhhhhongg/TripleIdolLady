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
        // ���콺 �������� ���� ���� ���� �����ͼ� ���� ��Ų�ٸ�?
        transform.Translate(new Vector3(1, 1, 0) * Time.deltaTime);
    }
    
}
