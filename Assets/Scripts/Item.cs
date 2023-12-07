using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Item : MonoBehaviour
{    
    // �÷��̾���� �浹 ó��
    // �÷��̾�� �浹�ϸ� �����+1, ��Ʈ�� �ı�

    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;        
        SpawnOutsideScreen();
        
    }    
    void SpawnOutsideScreen()
    {
        Vector2 _playerPosition = Camera.main.ScreenToWorldPoint(_player.position);

        float screenWidth = Screen.width ;
        float screenHeight = Screen.height;

        float randomDirection = Random.Range(0f, 360f);

        float radius = Mathf.Sqrt(Mathf.Pow(screenWidth * 0.5f, 2) + Mathf.Pow(screenHeight * 0.5f, 2)) * 0.5f;
        float x = Mathf.Cos(randomDirection * Mathf.Deg2Rad) * radius + screenWidth * 0.5f;
        float y = Mathf.Sin(randomDirection * Mathf.Deg2Rad) * radius + screenHeight * 0.5f;

        Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector2(x, y));

        Vector2 newAim = spawnPosition;

        transform.position = new Vector2(newAim.x, newAim.y);
        
    }
}
