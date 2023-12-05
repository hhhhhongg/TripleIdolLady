using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBoss : MonoBehaviour
{
    public string enemyName;
    public int health;

    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;

    public GameObject player;
    public ObjectManager objectManager;

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

        Invoke("Think", 2);
    }

    void Think()
    {
        patternIndex = patternIndex == 3 ? 0 : patternIndex + 1;
        curPatternCount = 0;

        switch (patternIndex)
        {
            case 0:
                FireFoward();
                break;
            case 1:
                FireShot();
                break;
            case 2:
                FireArc();
                break;
            case 3:
                FireAround();
                break;
        }
    }

    void FireFoward()
    {
        //4발 발사 패턴
        GameObject BossBulletL = objectManager.MakeObj("BossBulletA");
        BossBulletL.transform.position = transform.position + Vector3.left * 0.3f;
        GameObject BossBulletLL = objectManager.MakeObj("BulletBossA");
        BossBulletLL.transform.position = transform.position + Vector3.left * 0.45f;
        GameObject BossBulletLLL = objectManager.MakeObj("BulletBossA");
        BossBulletLLL.transform.position = transform.position + Vector3.left * 0.3f;
        GameObject BossBulletLLLL = objectManager.MakeObj("BulletBossA");
        BossBulletLLLL.transform.position = transform.position + Vector3.left * 0.3f;

        Rigidbody2D rigidL = BossBulletL.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidLL = BossBulletLL.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidLLL = BossBulletLLL.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidLLLL = BossBulletLLLL.GetComponent<Rigidbody2D>();

        rigidL.AddForce(Vector2.left * 8, ForceMode2D.Impulse);
        rigidLL.AddForce(Vector2.left * 8, ForceMode2D.Impulse);
        rigidLLL.AddForce(Vector2.left * 8, ForceMode2D.Impulse);
        rigidLLLL.AddForce(Vector2.left * 8, ForceMode2D.Impulse);

        //패턴카운트
        curPatternCount++;
        if(curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireFoward", 2);
        else
        Invoke("Think", 2);
    }
    void FireShot()
    {
        for(int index=0; index < 5; index++)
        {
            GameObject bullet = objectManager.MakeObj("BossBulletB");
            bullet.transform.position = transform.position;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = player.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(0f, 5f), Random.Range(-1f, 1f));
            dirVec += ranVec;
            rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
        }
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireShot", 2);
        else
            Invoke("Think", 2);
    }
    void FireArc()
    {
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireArc",0.15f);
        else
            Invoke("Think", 2);
    }
    void FireAround()
    {
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireAround", 0.7f);
        else
            Invoke("Think", 2);
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
