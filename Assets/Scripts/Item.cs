using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Item : MonoBehaviour
{
    // �÷��̾ �������� ����
    // �÷��̾���� �浹 ó��
    // �÷��̾�� �浹�ϸ� �����+1, ��Ʈ�� �ı�


    private Transform _player;    

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;        
        SpawnOutsideScreen();
        
    }    
    void Update()
    {
        
    }    
    
    void SpawnOutsideScreen()
    {
        Vector2 _playerPosition = Camera.main.ScreenToWorldPoint(_player.position);

        float screenWidth = Screen.width * 0.1f;
        float screenHeight = Screen.height * 0.1f;

        float randomDirection = Random.Range(0f, 360f);

        
        float x = Mathf.Cos(randomDirection * Mathf.Deg2Rad) * screenWidth;
        float y = Mathf.Sin(randomDirection * Mathf.Deg2Rad) * screenHeight;

        Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector2(x, y));

        Vector2 newAim = spawnPosition - _playerPosition;

        transform.position = new Vector2(newAim.x, newAim.y);
        Debug.Log(newAim);
    }
}
