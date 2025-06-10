using UnityEngine;
using UnityEngine.Video;

public class SettingsManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoScreen;      // UI elementas, kuriame rodomas video (pvz., RawImage)
    public GameObject backgroundPanel;  // tavo pagrindinis fonas/Canvas, kurį paslėpsim

    void Start()
    {
        // Paslepiame video ekraną ir įsitikiname, kad fonas įjungtas
        if (videoScreen != null)
            videoScreen.SetActive(false);

        if (backgroundPanel != null)
            backgroundPanel.SetActive(true);

        // Užregistruojame callback, kai video pasibaigia
        if (videoPlayer != null)
            videoPlayer.loopPointReached += OnVideoEnd;
    }

    public void PlaySoundVideo()
    {
        // Paslepiame foną ir parodome video
        if (backgroundPanel != null)
            backgroundPanel.SetActive(false);

        if (videoScreen != null)
            videoScreen.SetActive(true);

        // Stabdom galbūt jau grojamą video ir paleidžiam iš naujo
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.Play();
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Kai video pasibaigia, vėl parodom foną ir slepiame video ekraną
        if (backgroundPanel != null)
            backgroundPanel.SetActive(true);

        if (videoScreen != null)
            videoScreen.SetActive(false);
    }
}
