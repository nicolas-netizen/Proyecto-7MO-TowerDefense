using UnityEngine;
using UnityEngine.SceneManagement;

public class UIgameOver : MonoBehaviour
{
    public string _sceneName;
    public string _sceneLevel;

    public void ChangeScene()
    {
        SceneManager.LoadScene(_sceneName);
        AudioListener.pause = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioListener.pause = false;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(_sceneLevel);
    }
}
