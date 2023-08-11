using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private Animator _camera;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GameOver()
    {
        _camera.enabled = true;
        _camera.Play("Lose");
    }

    public void Win()
    {
        _camera.Play("Win");
    }
}
