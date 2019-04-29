using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float moveSpeed;

    private BulletManager bulletManager;

    SoundManager sm;

    void Awake()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void Start()
    {
        Debug.Log("I LIVE!!");
        bulletManager = GameObject.Find("BulletManager").GetComponent<BulletManager>();
    }

    private void Update()
    {
        Vector3 mPos = new Vector3(bulletManager.mousePos.x, bulletManager.mousePos.y, 0);

        transform.position = Vector3.MoveTowards(transform.position, mPos,  moveSpeed * Time.deltaTime);

        if(transform.position == mPos)
        {
            bulletManager.currentPlayerShotsLeft += Mathf.Abs(bulletManager.maxPlayerBullets - bulletManager.currentPlayerShotsLeft);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            sm.PlaySound(sm.sounds[2]);
            Destroy(collision.gameObject);
            bulletManager.currentPlayerShotsLeft += Mathf.Abs(bulletManager.maxPlayerBullets - bulletManager.currentPlayerShotsLeft);
            Destroy(gameObject);
        }

        if (!collision.gameObject.CompareTag("Enemy") && !collision.gameObject.CompareTag("Enemy_Bullet"))
        {
            Debug.Log("Your shot hit something else!");
            bulletManager.currentPlayerShotsLeft += Mathf.Abs(bulletManager.maxPlayerBullets - bulletManager.currentPlayerShotsLeft);
            Destroy(gameObject);
        }
    }
}
