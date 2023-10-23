using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private static bool _paused = false;
    [SerializeField] private GameObject _pausedCanvas;
    [SerializeField] private GameObject _ControllerMenu;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_paused == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.05f;
        _pausedCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        AudioListener.pause = true;
    }
    public void Controller()
    {
        Time.timeScale = 0.05f;
        _ControllerMenu.SetActive(true);
        AudioListener.pause = true;
        _pausedCanvas.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        _pausedCanvas.SetActive(false);
        AudioListener.pause = false;
        _ControllerMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
