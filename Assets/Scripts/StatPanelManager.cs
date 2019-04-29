using UnityEngine;
using UnityEngine.UI;

public class StatPanelManager : MonoBehaviour
{
    public Slider slider;
    public Text numberOfShots;
    public Text suitAbsorption;
    public Text sliderText;
    
    public void SetLifeforce(int amount)
    {
        slider.value = amount;
        sliderText.text = slider.value.ToString();
    }

    public void SetLifeforceMaxValue(int amount)
    {
        slider.maxValue = amount;
    }

    public void SetNumberOfShots(int amount)
    {
        numberOfShots.text = amount.ToString();
    }

    public void SetSuitAbsorption(float amount)
    {
        suitAbsorption.text = amount.ToString();
    }
}
