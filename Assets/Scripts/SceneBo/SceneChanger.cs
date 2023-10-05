using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private AudioSource clickSound; 

    public void PlayWithFade()
    {
        fadeAnimator.SetTrigger("Menu");
        if (clickSound != null)
        {
            clickSound.Play();
        }
        Invoke("ChangeScene", fadeAnimator.GetCurrentAnimatorStateInfo(0).length);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
