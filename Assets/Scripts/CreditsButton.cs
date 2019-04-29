using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    private FadeInAndOut fadeInAndOut;

    private void Start()
    {
        fadeInAndOut = GameObject.Find("Fader").GetComponent<FadeInAndOut>();
    }

    public void BackToTitlescreen()
    {
        fadeInAndOut.DoFade(0);
    }
}
