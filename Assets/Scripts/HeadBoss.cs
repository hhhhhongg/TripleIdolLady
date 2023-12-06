using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBoss : MonoBehaviour
{
    public string enemyName;
    public int health;
    private int _damage = 0;

    public float maxShotDelay;
    public float curShotDelay;

    public int patternIndex;
    public int curPatternCount;

    public GameObject player;
    public ObjectManager objectManager;

    public GameObject BossBulletA;
    public GameObject BossBulletB;
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

    private void OnEnable()
    {
        switch (enemyName)
        {
            case "B":
                health = 3000;
                Invoke("Stop", 2);
                break;
        }
    }

    void Stop()
    {
        if (!gameObject.activeSelf)
            return;

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;

        Invoke("Think", 1);
    }

    void Think()
    {
        patternIndex = patternIndex >= 2 ? 0 : patternIndex + 1;
        curPatternCount = 0;

        switch (patternIndex)
        {
            
            case 0:
                FireShot();
                break;
            case 1:
                FireArc();
                break;
            case 2:
                FireAround();
                break;
        }
    }

    
    void FireShot()
    {
        for (int index = 0; index < 20; index++)
        {
            GameObject BossBullet = objectManager.MakeObj("BossBulletB");
            BossBullet.transform.position = transform.position;

            Rigidbody2D rigid = BossBullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = player.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(0f, 5f), Random.Range(-1f, 1f));
            dirVec += ranVec;
            rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
        }
        curPatternCount++;
        if (curPatternCount < 2)
            Invoke("FireShot", 2);
        else
            Invoke("Think", 2);
    }
    void FireArc()
    {
        GameObject BossBullet = objectManager.MakeObj("BossBulletA");
        BossBullet.transform.position = transform.position;
        BossBullet.transform.rotation = Quaternion.identity;

        Rigidbody2D rigid = BossBullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(-1, Mathf.Cos(curPatternCount));
        rigid.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);
        curPatternCount++;
        if (curPatternCount < 50)
            Invoke("FireArc", 0.15f);
        else
            Invoke("Think", 2);
    }
    void FireAround()
    {
        int roundNumA = 30;
        for (int index = 0; index < roundNumA; index++)
        {
            GameObject BossBullet = objectManager.MakeObj("BossBulletB");
            BossBullet.transform.position = transform.position;
            BossBullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rigid = BossBullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / roundNumA)
                                        ,Mathf.Sin(Mathf.PI * 2 * index / roundNumA));
            rigid.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);
        }
        curPatternCount++;
        if (curPatternCount < 30) { 
            Invoke("FireAround", 0.1f);
        }
        else
            Invoke("Think", 2);
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;
        if(enemyName == "B")
        {
            GameObject BossBulletA = objectManager.MakeObj("BossBulletA");
            BossBulletA.transform.position = transform.position;

            Rigidbody2D rigid = BossBulletA.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - transform.position;
            rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet1")
        {
            TakeDamage(collider, 2);
        }
        else if (collider.gameObject.tag == "Bullet2")
        {
            TakeDamage(collider, 3);
        }
        else if (collider.gameObject.tag == "Bullet3")
        {
            TakeDamage(collider, 4);
        }
    }


    private void TakeDamage(Collider2D collider, int _bulletDamage)
    {
        if (_damage < health)
        {
            _damage += _bulletDamage;
            health -= _damage;
        }
        else
        {
            health = 0;
            Die();
        }
    }
    private void Die()
    {
        gameObject.SetActive(false);
        GameManager.instance.BossIsDead = true;
    }
}