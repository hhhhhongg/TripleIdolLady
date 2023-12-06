using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 3;  // �ִ� ��� ����
    private int currentLives;  // ���� ��� ����

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

        // ����� 0�� �Ǹ� ���� ���� ó��
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
        // ���� ���� ó��
        // ��: ȭ�鿡 "���� ����" �޽����� ǥ���ϰų� �ٸ� ó���� ����
    }

    
}

