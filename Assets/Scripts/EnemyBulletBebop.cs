using UnityEngine;

public class EnemyBulletBebop : MonoBehaviour
{
    public float moveSpeed;

    private BulletManager bulletManager;
    private EnemyBebop enemyBebop;
    private Vector3 playerPos;

    private void Start()
    {
        Debug.Log("OFF AND AWAY!");
        bulletManager = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        playerPos = GameObject.Find("Player").transform.position;
        enemyBebop = GameObject.Find("EnemyBebop").GetComponent<EnemyBebop>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);

        if (transform.position == playerPos)
        {
            enemyBebop.justFired = true;
            bulletManager.currentEnemyBebopShotsLeft += Mathf.Abs(bulletManager.maxBebopBullets - bulletManager.currentEnemyBebopShotsLeft);
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
            enemyBebop.justFired = true;
            bulletManager.currentEnemyBebopShotsLeft += Mathf.Abs(bulletManager.maxBebopBullets - bulletManager.currentEnemyBebopShotsLeft);
            Destroy(gameObject);
        }
        else
        {
            enemyBebop.justFired = true;
            bulletManager.currentEnemyBebopShotsLeft += Mathf.Abs(bulletManager.maxBebopBullets - bulletManager.currentEnemyBebopShotsLeft);
            Destroy(gameObject);
        }

        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Player_Bullet"))
        {
            Debug.Log("Enemy shot hit something else!");
            enemyBebop.justFired = true;
            bulletManager.currentEnemyBebopShotsLeft += Mathf.Abs(bulletManager.maxBebopBullets - bulletManager.currentEnemyBebopShotsLeft);
            Destroy(gameObject);
        }
    }
}
