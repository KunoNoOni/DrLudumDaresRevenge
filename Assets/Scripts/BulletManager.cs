using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject playerBullet;
    public GameObject enemyBulletBebop;
    public GameObject enemyBulletMandar;
    public Vector2 mousePos;
    public int maxPlayerBullets;
    public int maxBebopBullets;
    public int maxSpinnaDoodleBullets;
    public int maxMandarBullets;
    public int currentPlayerShotsLeft;
    public int currentEnemyBebopShotsLeft;
    public int currentEnemySpinnaDoodleShotsLeft;
    public int currentMandarShotsLeft;
    public bool playerHasShield = false;
    
    public void CreatePlayerBullet(float x, float y)
    {
        Instantiate(playerBullet, new Vector3(x, y, 0), Quaternion.identity);
    }

    public void CreateEnemyBulletBebop(float x, float y)
    {       
        Instantiate(enemyBulletBebop, new Vector3(x, y, 0), Quaternion.identity);
    }

    public void CreateEnemyBulletMandar(float x, float y)
    {
        Instantiate(enemyBulletMandar, new Vector3(x, y, 0), Quaternion.identity);
    }
}
