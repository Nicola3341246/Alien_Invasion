using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Screen : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject[] otherMenus;

    bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        foreach (var menu in otherMenus)
        {
            menu.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void GotToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
