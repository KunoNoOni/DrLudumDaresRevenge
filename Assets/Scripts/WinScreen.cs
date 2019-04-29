using UnityEngine;

public class WinScreen : MonoBehaviour
{
    private FadeInAndOut fadeInAndOut;
    MusicManager mm;

    void Awake()
    {
        mm = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }

    private void Start()
    {
        mm.PlaySound(mm.music[2]);
        fadeInAndOut = GameObject.Find("Fader").GetComponent<FadeInAndOut>();
    }

    public void BackToTitle()
    {
        fadeInAndOut.DoFade(0);
    }
}
