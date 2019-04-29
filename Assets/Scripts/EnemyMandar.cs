using UnityEngine;

public class EnemyMandar : MonoBehaviour
{
    public int numberOfShots;
    public bool justFired = false;

    private bool nextShot = false;
    private BulletManager bulletManager;
    private float cooldown;
    private float cooldownReset;
    private float cooldownNextShot;
    private float cooldownResetNextShot;


    private void Start()
    {
        cooldownReset = 2f;
        cooldownResetNextShot = 1f;
        cooldown = cooldownReset;
        cooldownNextShot = cooldownResetNextShot;
        bulletManager = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        bulletManager.currentMandarShotsLeft = numberOfShots;
        bulletManager.maxMandarBullets = 2;
        
    }

    void Update()
    {
        if(justFired)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                justFired = false;
                cooldown = cooldownReset;
            }
        }

        if (nextShot)
        {
            cooldownNextShot -= Time.deltaTime;
            if (cooldownNextShot <= 0)
            {
                nextShot = false;
                cooldownNextShot = cooldownResetNextShot;
            }
        }

        if (bulletManager.currentMandarShotsLeft > 0 && !justFired && !nextShot)
        {
            nextShot = true;
            bulletManager.currentMandarShotsLeft--;
            bulletManager.CreateEnemyBulletMandar(transform.position.x, transform.position.y);
        }
    }
}
