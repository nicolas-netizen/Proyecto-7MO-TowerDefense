using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private static bool _paused = false;
    [SerializeField] private GameObject _pausedCanvas;

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
        Time.timeScale = 0f;
        _pausedCanvas.SetActive(true);
        _paused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        _pausedCanvas.SetActive(false);
        _paused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
