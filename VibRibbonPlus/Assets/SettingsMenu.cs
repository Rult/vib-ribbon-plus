using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public TMP_Dropdown resolutionDropdown;

    public Toggle Fullscreen;

    public Slider Volume;

    public Slider RenderDis;


    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

            Fullscreen.isOn = Screen.fullScreen;

        resolutionDropdown.value = QualitySettings.GetQualityLevel();

        Volume.value = PlayerPrefs.GetFloat("Vol", 0f);

        RenderDis.value = PlayerPrefs.GetInt("Render", 20);
        GameObject.Find("Distance").GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Render", 20).ToString();

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume (float volume)
    {
        Debug.Log(volume);
        AudioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Vol", volume);
    }

    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution( int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetRender(float Distance)
    {
        GameObject.Find("Game Manager").GetComponent<ChangeScene>().RenderDistance = (int)Distance;
        GameObject.Find("Distance").GetComponent<TextMeshProUGUI>().text = Distance.ToString();
        PlayerPrefs.SetInt("Render", (int)Distance);
    }
}
