using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBoss : MonoBehaviour
{
    public string enemyName;
    public int health;


    public GameObject BulletObj1;
    public GameObject BulletObj2;
    void Update()
    {
        if (enemyName == "B")
            return;
    }
    public void OnHit(int dmg)
    {
        if (health <= 0)
            return;
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet" && enemyName !="B")
        {
            gameObject.SetActive(false);
            transform.rotation = Quaternion.identity;
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            BossBullet1 bullet = collision.gameObject.GetComponent<BossBullet1>();
            OnHit(bullet.dmg);

            collision.gameObject.SetActive(false);
        }
    }
}
