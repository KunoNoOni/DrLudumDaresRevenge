using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMandar : MonoBehaviour
{
    public float moveSpeed;

    private BulletManager bulletManager;
    private EnemyMandar enemyMandar;
    private Vector3 playerPos;

    private void Start()
    {
        Debug.Log("OFF AND AWAY!");
        bulletManager = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        playerPos = GameObject.Find("Player").transform.position;
        enemyMandar = GameObject.Find("Enemy3Mandar").GetComponent<EnemyMandar>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);

        if (transform.position == playerPos)
        {
            enemyMandar.justFired = true;
            bulletManager.currentMandarShotsLeft += Mathf.Abs(bulletManager.maxMandarBullets - bulletManager.currentEnemyBebopShotsLeft);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !bulletManager.playerHasShield)
        {
            Debug.Log("Enemy shot hit!");
            Debug.Log(collision.gameObject.tag);
            Destroy(collision.gameObject);
            enemyMandar.justFired = true;
            bulletManager.currentMandarShotsLeft += Mathf.Abs(bulletManager.maxMandarBullets - bulletManager.currentMandarShotsLeft);
            Destroy(gameObject);
        }
        else
        {
            enemyMandar.justFired = true;
            bulletManager.currentMandarShotsLeft += Mathf.Abs(bulletManager.maxMandarBullets - bulletManager.currentMandarShotsLeft);
            Destroy(gameObject);
        }

        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Player_Bullet"))
        {
            Debug.Log("Enemy shot hit something else!");
            enemyMandar.justFired = true;
            bulletManager.currentMandarShotsLeft += Mathf.Abs(bulletManager.maxMandarBullets - bulletManager.currentMandarShotsLeft);
            Destroy(gameObject);
        }
    }
}
