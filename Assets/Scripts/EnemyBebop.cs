using UnityEngine;

public class EnemyBebop : MonoBehaviour
{
    public int numberOfShots;
    public bool justFired = false;

    private BulletManager bulletManager;
    private float cooldown;
    private float cooldownReset;
    

    private void Start()
    {
        cooldownReset = 3f;
        cooldown = cooldownReset;
        bulletManager = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        bulletManager.currentEnemyBebopShotsLeft = numberOfShots;
        bulletManager.maxBebopBullets = 1;
    }

    void Update()
    {
        if(justFired)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                Debug.Log("Ready to fire another shot!");
                Debug.Log("current shots left: " + bulletManager.currentEnemyBebopShotsLeft);
                justFired = false;
                cooldown = cooldownReset;
            }
        }

        if(bulletManager.currentEnemyBebopShotsLeft > 0 && !justFired)
        {
            bulletManager.currentEnemyBebopShotsLeft--;
            bulletManager.CreateEnemyBulletBebop(transform.position.x, transform.position.y);
        }
    }
}
