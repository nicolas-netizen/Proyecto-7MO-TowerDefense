using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    public Animator fadeAnimator; 
    [SerializeField] private RawImage _imgFade;


    public void PlayWithFade()
    {
        _imgFade.GetComponent<Animator>().Play("FadeOut");
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
