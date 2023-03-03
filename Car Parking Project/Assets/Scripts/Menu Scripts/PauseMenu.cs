using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject resumePanel;
    public GameObject gameCanvas;

    public AudioSource uiAudio;
    public AudioClip uiClip;

    private void Start()
    {
        resumePanel.SetActive(false);
        gameCanvas.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && resumePanel.activeInHierarchy == false)
        {
            resumePanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            gameCanvas.SetActive(false);
        }

        #region //Cursor Code
        if (resumePanel.activeInHierarchy)
        {
            Cursor.visible = true;
        }

        if (!resumePanel.activeInHierarchy)
        {
            Cursor.visible = false;
        }
        #endregion
    }

    public void Pause() 
    {
        resumePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        gameCanvas.SetActive(false);

    }

    public void Resume()
    {
        resumePanel.SetActive(false);
        Time.timeScale = 1;
        uiAudio.PlayOneShot(uiClip);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        gameCanvas.SetActive(true);
    }

    public void RestartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        
    }

    public void GoToMainMenu() 
    {
        SceneManager.LoadScene("Main Menu");
        uiAudio.PlayOneShot(uiClip);
    }
}
