using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : MonoBehaviour
{
    public float Speed;
    public int Health;
    Rigidbody2D Rigid;

    private void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Rigid.velocity = Vector2.left * Speed;
    }

    void OnHit(int dmg)
    {
        Health -= dmg;

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            BossBullet1 bullet = collision.gameObject.GetComponent<BossBullet1>();
            OnHit(bullet.dmg);

            Destroy(collision.gameObject);
        }
            

    }
}
