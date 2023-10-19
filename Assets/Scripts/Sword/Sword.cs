using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private ISwordOwner _owner;
    private CameraShake _cameraShake;
    private AudioSource _audioSource; 

    public AudioClip hitSoundRight; 
    private void Start()
    {
        _owner = transform.root.GetComponent<ISwordOwner>();
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var col = other.gameObject?.GetComponent<IDamageable>();

        if (col != null)
        {
            if (col.GetObject() != _owner.GetOwner() && _owner.CheckAttacking())
            {
                switch (_owner.CheckAttackDir())
                {
                    case AttackDir.Right:
                        col.TakeDamage(_owner.GetDamage(), -_owner.GetOwner().transform.forward);
                        break;
                    case AttackDir.Left:
                        col.TakeDamage(_owner.GetDamage(), _owner.GetOwner().transform.forward);
                        break;
                    default:
                        break;
                }

                if (_cameraShake != null)
                {
                    _cameraShake.Shake(_cameraShake.ShakeMagnitude);
                }

                if(!_audioSource.isPlaying)
                    _audioSource.Play();

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var col = other.gameObject?.GetComponent<IDamageable>();
        if (col != null)
        {
            if (col.GetObject() != _owner.GetOwner() && _owner.CheckAttacking())
            {
                switch (_owner.CheckAttackDir())
                {
                    case AttackDir.Right:
                        col.TakeDamage(_owner.GetDamage(), -_owner.GetOwner().transform.forward);
                        break;
                    case AttackDir.Left:
                        col.TakeDamage(_owner.GetDamage(), _owner.GetOwner().transform.forward);
                        break;
                    default:
                        break;
                }

                if (_cameraShake != null)
                {
                    _cameraShake.Shake(_cameraShake.ShakeMagnitude);

                }
                Debug.Log("La espada permanece en colisión con: " + col.GetObject().name); // Mensaje de depuración
            }
        }
    }
}

