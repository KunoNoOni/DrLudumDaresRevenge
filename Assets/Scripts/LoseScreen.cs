using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    private FadeInAndOut fadeInAndOut;
    MusicManager mm;

    void Awake()
    {
        mm = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }

    private void Start()
    {
        mm.PlaySound(mm.music[3]);
        fadeInAndOut = GameObject.Find("Fader").GetComponent<FadeInAndOut>();
    }

    public void BackToTitle()
    {
        fadeInAndOut.DoFade(0);
    }
}
