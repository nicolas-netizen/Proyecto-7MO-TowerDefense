using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("IN GAME MENU")]
    [SerializeField] private RawImage _imgFade;
    [SerializeField] private GameObject[] _enemyIcons;
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
        count = Mathf.Clamp(count, 0, enemiesMax);

        for (int i = 0; i < _enemyIcons.Length; i++)
        {
            if (i < count)
            {
                _enemyIcons[i].SetActive(true);
            }
            else
            {
                _enemyIcons[i].SetActive(false);
            }
        }
    }
    public void FadeIn()
    {
        if (_isFading)
            return;

        _isFading = true;
        _imgFade.GetComponent<Animator>().Play("FadeIn");
    }
}
