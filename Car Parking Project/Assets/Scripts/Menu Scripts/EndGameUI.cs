using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    public int loadedScene;

    private void Start()
    {
        loadedScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerPrefs.SetInt("levelAt", loadedScene + 1);

        if (loadedScene > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", loadedScene);
        }

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
