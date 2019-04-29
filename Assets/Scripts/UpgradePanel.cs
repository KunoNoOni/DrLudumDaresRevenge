using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    private PlayerController playerController;
    private StatPanelManager statPanelManager;
    private BulletManager bulletManager;
    private int lifeforceUpgradeLevel = 0;
    private int bulletsUpgradeLevel = 0;
    private int suitUpgradeLevel = 0;
    private float lifeforceToTake;
    public Text quantumEnergyBalls;
    public Text currentLifeforceUsed;
    public Image lifeforceLevel1;
    public Image lifeforceLevel2;
    public Image lifeforceLevel3;
    public Image lifeforceLevel4;
    public Image lifeforceLevel5;
    public Image bulletsLevel1;
    public Image bulletsLevel2;
    public Image bulletsLevel3;
    public Image bulletsLevel4;
    public Image bulletsLevel5;
    public Image suitLevel1;
    public Image suitLevel2;
    public Image suitLevel3;
    public Image suitLevel4;
    public Image suitLevel5;
    public Button lifeforceUpgradeButton;
    public Button bulletsUpgradeButton;
    public Button suitUpgradeButton;

    private Color lit = new Color(255, 255, 0);

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        statPanelManager = GameObject.Find("Canvas").GetComponent<StatPanelManager>();
        bulletManager = GameObject.Find("BulletManager").GetComponent<BulletManager>();
    }

    public void SetQuantumEnergyBalls(int amount)
    {
        quantumEnergyBalls.text =  amount.ToString();
    }

    public void UpgradeLifeforce()
    {
        if (playerController.numberOfQuantumEnergyBalls > 0 && (Mathf.Abs(playerController.lifeForce - lifeforceToTake) < playerController.lifeForce))
        {
            lifeforceUpgradeLevel++;
            switch(lifeforceUpgradeLevel)
            {
                case 1:
                    lifeforceLevel1.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 2:
                    lifeforceLevel2.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 3:
                    lifeforceLevel3.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 4:
                    lifeforceLevel4.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 5:
                    lifeforceLevel5.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
            }

            playerController.lifeForce -= (int)lifeforceToTake;
            statPanelManager.SetLifeforce(playerController.lifeForce);

            playerController.maxLifeforce += 5;
            statPanelManager.SetLifeforceMaxValue(playerController.maxLifeforce);
        }

        if(lifeforceUpgradeLevel == 5)
        {
            lifeforceUpgradeButton.GetComponentInChildren<Text>().text = "MAXED";
            lifeforceUpgradeButton.enabled = false;
        }
    }

    public void UpgradeBullets()
    {
        if (playerController.numberOfQuantumEnergyBalls > 0 && (Mathf.Abs(playerController.lifeForce - lifeforceToTake) < playerController.lifeForce))
        {
            bulletsUpgradeLevel++;
            switch (bulletsUpgradeLevel)
            {
                case 1:
                    bulletsLevel1.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 2:
                    bulletsLevel2.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 3:
                    bulletsLevel3.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 4:
                    bulletsLevel4.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 5:
                    bulletsLevel5.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
            }

            playerController.lifeForce -= (int)lifeforceToTake;
            statPanelManager.SetLifeforce(playerController.lifeForce);

            playerController.numberOfShots += 1;
            bulletManager.currentPlayerShotsLeft = playerController.numberOfShots;
            bulletManager.maxPlayerBullets = playerController.numberOfShots;
            statPanelManager.SetNumberOfShots(playerController.numberOfShots);
        }

        if (bulletsUpgradeLevel == 5)
        {
            bulletsUpgradeButton.GetComponentInChildren<Text>().text = "MAXED";
            bulletsUpgradeButton.enabled = false;
        }
    }

    public void UpgradeSuit()
    {
        if (playerController.numberOfQuantumEnergyBalls > 0 && (Mathf.Abs(playerController.lifeForce - lifeforceToTake) < playerController.lifeForce))
        {
            suitUpgradeLevel++;
            switch (suitUpgradeLevel)
            {
                case 1:
                    suitLevel1.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 2:
                    suitLevel2.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 3:
                    suitLevel3.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 4:
                    suitLevel4.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
                case 5:
                    suitLevel5.color = lit;
                    playerController.numberOfQuantumEnergyBalls--;
                    SetQuantumEnergyBalls(playerController.numberOfQuantumEnergyBalls);
                    break;
            }

            playerController.lifeForce -= (int)lifeforceToTake;
            statPanelManager.SetLifeforce(playerController.lifeForce);

            playerController.suitPercentage -= .5f;
            statPanelManager.SetSuitAbsorption(playerController.suitPercentage);
            CalculateLifeforceToUse(playerController.suitPercentage, playerController.lifeForce);
        }

        if (suitUpgradeLevel == 5)
        {
            suitUpgradeButton.GetComponentInChildren<Text>().text = "MAXED";
            suitUpgradeButton.enabled = false;
        }
    }

    public void CalculateLifeforceToUse(float suitPercentage, int lifeforce)
    {
        lifeforceToTake = Mathf.Ceil((suitPercentage / lifeforce) * 100);
        currentLifeforceUsed.text = lifeforceToTake.ToString();
    }

    public bool CalculateIfUsingWillKillYou()
    {
        return Mathf.Abs(playerController.lifeForce - lifeforceToTake) < playerController.lifeForce;
    }

}
