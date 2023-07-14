using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("IN GAME MENU")]
    [SerializeField] private RawImage _imgFade;
    [SerializeField] private TextMeshProUGUI _txtEnemyEndCounter;

    private bool _isFading = false;
    public static UIManager Instance;

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SetEnemyAtEndCounter(int count, int enemiesMax)
    {
        _txtEnemyEndCounter.text = count + "/" + enemiesMax;
    }

    public void FadeIn()
    {
        if (_isFading)
            return;

        _isFading = true;
        _imgFade.GetComponent<Animator>().Play("FadeIn");
    }
}
