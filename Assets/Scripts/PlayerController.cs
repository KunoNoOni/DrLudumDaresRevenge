using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public int lifeForce;
    public int maxLifeforce;
    public int numberOfShots;
    public float suitPercentage;
    public int numberOfQuantumEnergyBalls;
    public bool upgradePanelOpen = false;

    private bool hasRedKey;
    private bool hasBlueKey;
    private bool hasYellowKey;
    private Rigidbody2D player;
    private Animator anim;
    private float moveHVelocity;
    private float moveVVelocity;
    private AudioSource asource;
    private BulletManager bulletManager;
    private float shieldCooldown;
    private float shieldCooldownReset;
    private StatPanelManager statsPanelManager;
    private UpgradePanel upgradePanel;
    SoundManager sm;

    void Awake()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        asource = GetComponent<AudioSource>();
        bulletManager = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        statsPanelManager = GameObject.Find("Canvas").GetComponent<StatPanelManager>();
        upgradePanel = GameObject.Find("UpgradePanel").GetComponent<UpgradePanel>();
        upgradePanel.gameObject.SetActive(false);
        bulletManager.currentPlayerShotsLeft = 1;
        bulletManager.maxPlayerBullets = numberOfShots;
        shieldCooldownReset = 10f;
        shieldCooldown = shieldCooldownReset;
        statsPanelManager.SetLifeforce(lifeForce);
        statsPanelManager.SetNumberOfShots(numberOfShots);
        statsPanelManager.SetSuitAbsorption(suitPercentage);
    }

    private void Update()
    {
        moveHVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
        moveVVelocity = moveSpeed * Input.GetAxisRaw("Vertical");
        player.velocity = new Vector2(moveHVelocity, moveVVelocity);

        if (player.velocity.x != 0 || player.velocity.y != 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isShooting", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("JoystickButton0")) && bulletManager.currentPlayerShotsLeft > 0 && !upgradePanelOpen)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isShooting", true);
            sm.PlaySound(sm.sounds[3]);
            bulletManager.currentPlayerShotsLeft--;
            bulletManager.mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            bulletManager.CreatePlayerBullet(transform.position.x, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("JoystickButton1"))
        {
            upgradePanelOpen = true;
            upgradePanel.gameObject.SetActive(true);
            upgradePanel.SetQuantumEnergyBalls(numberOfQuantumEnergyBalls);
            upgradePanel.CalculateLifeforceToUse(suitPercentage, lifeForce);
        }

        if(anim.GetBool("hasShield"))
        {
            shieldCooldown -= Time.deltaTime;
            if (shieldCooldown <= 0)
            {
                anim.SetBool("hasShield", false);
                bulletManager.playerHasShield = false;
                shieldCooldown = shieldCooldownReset;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        Debug.Log("Collided with " + collision2D.gameObject.tag);
        switch (collision2D.gameObject.tag)
        {
            case "Health_Powerup":
                sm.PlaySound(sm.sounds[1]);
                if (Mathf.Abs(maxLifeforce-lifeForce)>0 && Mathf.Abs(maxLifeforce - lifeForce) <= 5)
                {
                    lifeForce = Mathf.Abs(maxLifeforce - lifeForce);
                    statsPanelManager.SetLifeforce(lifeForce);
                }
                else if(Mathf.Abs(maxLifeforce - lifeForce)>0)
                {
                    lifeForce += 5;
                    statsPanelManager.SetLifeforce(lifeForce);
                }
                DeactivateObject(collision2D.gameObject);
                break;
            case "Shield_Powerup":
                sm.PlaySound(sm.sounds[1]);
                anim.SetBool("hasShield", true);
                bulletManager.playerHasShield = true;
                DeactivateObject(collision2D.gameObject);
                break;
            case "QuantumEnergyBall":
                sm.PlaySound(sm.sounds[1]);
                numberOfQuantumEnergyBalls++;                
                DeactivateObject(collision2D.gameObject);
                break;
            case "Red_Key":
                sm.PlaySound(sm.sounds[1]);
                hasRedKey = true;
                DeactivateObject(collision2D.gameObject);
                break;
            case "Blue_Key":
                sm.PlaySound(sm.sounds[1]);
                hasBlueKey = true;
                DeactivateObject(collision2D.gameObject);
                break;
            case "Yellow_Key":
                sm.PlaySound(sm.sounds[1]);
                hasYellowKey = true;
                DeactivateObject(collision2D.gameObject);
                break;
            case "Red_Door":
                if(hasRedKey)
                {
                    sm.PlaySound(sm.sounds[0]);
                    DeactivateObject(collision2D.gameObject);
                }
                break;
            case "Blue_Door":
                if (hasBlueKey)
                {
                    sm.PlaySound(sm.sounds[0]);
                    DeactivateObject(collision2D.gameObject);
                }
                break;
            case "Yellow_Door":
                if (hasYellowKey)
                {
                    sm.PlaySound(sm.sounds[0]);
                    DeactivateObject(collision2D.gameObject);
                }
                break;
            case "Enemy":
            case "EnergyWall":
                //put in code to kill the player
                DeactivateObject(gameObject);
                SceneManager.LoadScene(4);
                break;
        }
    }

    private void DeactivateObject(GameObject go)
    {
        go.SetActive(false);
    }

    public void SetUpgradePanelOpenToFalse()
    {
        upgradePanelOpen = false;
    }
}
