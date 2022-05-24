using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public TextMeshProUGUI volume;
    public TextMeshProUGUI onSound;
    public TextMeshProUGUI offSound;
    public TextMeshProUGUI sensitivity;
    public TextMeshProUGUI speed;

    public GameObject soundOnButton;
    public GameObject soundOffButton;

    public static int sound = 1;
    public static int volumeLevelDisplay = 7;
    public static float volumeLevel = 0.7f;

    public AudioSource blip;
    public AudioSource ballBlip;

    public void Start()
    {
        VolumeSetting();
        SoundCheck();
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LeftVol()
    {
        if (volumeLevelDisplay > 0)
        {
            volumeLevelDisplay -= 1;
            volume.text = volumeLevelDisplay.ToString();
            volumeLevel = volumeLevelDisplay * 0.1f;
            blip.volume = volumeLevel;
            ballBlip.volume = volumeLevel;
        }
    }
    public void RightVol()
    {
        if (volumeLevelDisplay < 9)
        {
            volumeLevelDisplay += 1;
            volume.text = volumeLevelDisplay.ToString();
            volumeLevel = volumeLevelDisplay * 0.1f;
            blip.volume = volumeLevel;
            ballBlip.volume = volumeLevel;
        }
    }

    // volume 0-9
    public void VolumeSetting()
    {
        LeftVol();
        RightVol();
    }

    public void OnSound()
    {
        soundOffButton.gameObject.SetActive(false);
        soundOnButton.gameObject.SetActive(true);
        sound = 1;

        onSound.text = "ON";
        AudioListener.pause = false;
    }
    public void OffSound()
    {
        soundOffButton.gameObject.SetActive(true);
        soundOnButton.gameObject.SetActive(false);
        sound = 0;

        offSound.text = "OFF";
        AudioListener.pause = true;
    }

    public void SoundCheck()
    {
        // if sound = 1, sound is on
        if (sound == 1)
        {
            OnSound();
        }

        // else if sound = 0, sound is off
        else if (sound == 0)
        {
            OffSound();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
