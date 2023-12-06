using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 3;  // 최대 목숨 개수
    private int currentLives;  // 현재 목숨 개수

    void Start()
    {
        currentLives = maxLives;
        GameManager.instance.UpdateLives(currentLives);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == ("Enemy"))
        {
            TakeDamage();
            Destroy(collider.gameObject);
        }
    }

    void TakeDamage()
    {
        currentLives--;

        // 목숨이 0이 되면 게임 오버 처리
        if (currentLives <= 0)
        {
            GameManager.instance.UpdateLives(currentLives);
            GameOver();
        }
        else
        {
            GameManager.instance.UpdateLives(currentLives);
        }
    }


    void GameOver()
    {
        Time.timeScale = 0f;
        // 게임 오버 처리
        // 예: 화면에 "게임 오버" 메시지를 표시하거나 다른 처리를 수행
    }

    
}

