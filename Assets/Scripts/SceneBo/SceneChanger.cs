using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private Animator fadeAnimator;

    public void PlayWithFade()
    {
        fadeAnimator.SetTrigger("FadeinMenu");
        Invoke("ChangeScene", fadeAnimator.GetCurrentAnimatorStateInfo(0).length);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
