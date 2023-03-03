using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject LevelOpener;

    public Slider loadingSlider;


    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdowns;

    public AudioSource uiAudio;
    public AudioClip uiClip;

    public GameObject optionMenu;
    public GameObject mainMenu;

    public GameObject controlMenu;

    private void Start()
    {
        LevelOpener.SetActive(false);
        loadingScreen.SetActive(false);
        optionMenu.SetActive(false);

        resolutions = Screen.resolutions;
        resolutionDropdowns.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdowns.AddOptions(options);
        resolutionDropdowns.value = currentResolutionIndex;
        resolutionDropdowns.RefreshShownValue();
    }

    public void PlayButton()
    {
        LevelOpener.SetActive(true);
        mainMenu.SetActive(false);
        optionMenu.SetActive(false);
    }


    #region // Async Loading
    public void AsyncPlay(int sceneIndex) 
    {
        StartCoroutine(LoadAsync(sceneIndex));

    }

    public void LevelBack()
    {
        uiAudio.PlayOneShot(uiClip);
        mainMenu.SetActive(true);
        LevelOpener.SetActive(false);

    }

    IEnumerator LoadAsync(int sceneIndex) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;

            yield return null;
        }
    }
    #endregion



    public void OptionsMenu() 
    {
        uiAudio.PlayOneShot(uiClip);
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void OptionBack() 
    {
        uiAudio.PlayOneShot(uiClip);
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);

    }

    public void ControlMenu() 
    {
        uiAudio.PlayOneShot(uiClip);
        mainMenu.SetActive(false);
        controlMenu.SetActive(true);
    }

    public void ControlBack()
    {
        uiAudio.PlayOneShot(uiClip);
        mainMenu.SetActive(true);
        controlMenu.SetActive(false);
    }

    public void QuitGame()
    {
        uiAudio.PlayOneShot(uiClip);
        Application.Quit();
        Debug.Log("quit");
        
    }

    public void FullScreen() 
    {
        Screen.fullScreen = !Screen.fullScreen;
        uiAudio.PlayOneShot(uiClip);
    }

    public void SetResolution(int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        
    }

    public void SetQuality( int qualityIndex)          // Graphics ( quality ) 
    {
        uiAudio.PlayOneShot(uiClip);
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}