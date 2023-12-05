using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    Transform playerTransform;

    void Awake()
    {
        
    }

    void LateUpdate()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.position = playerTransform.position + new Vector3(0,0,-15);
    }
}
