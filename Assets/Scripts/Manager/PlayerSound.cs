using System.Collections;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip runSound;
    [SerializeField] private AudioClip idleSound;

    private void Update()
    {
        if (_playerMovement.MovementState == MovementState.Running)
        {
            if (!_audioSource.isPlaying || _audioSource.clip != runSound)
            {
                _audioSource.clip = runSound;
                _audioSource.Play();
            }
        }
        else
        {
            if (!_audioSource.isPlaying || _audioSource.clip != idleSound)
            {
                _audioSource.clip = idleSound;
                _audioSource.Play();
            }
        }
    }
}

