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

        if (collider.gameObject.tag == "HeartItem")
        {
            GetHeartItem();
            Destroy(collider.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == ("BossBullet"))
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
        }
        else
        {
            GameManager.instance.UpdateLives(currentLives);
        }
    }
    void GetHeartItem()
    {
        currentLives++;
        GameManager.instance.UpdateLives(currentLives);
    }
}

