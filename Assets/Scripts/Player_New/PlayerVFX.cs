using UnityEngine;

[System.Serializable]
public class PlayerVFX
{
    [Header("PARTICLES")]
    [SerializeField] private ParticleSystem _bloodParticles;
    [SerializeField] private ParticleSystem _hitParticles;
    [SerializeField] private ParticleSystem _dashParticles;
    [SerializeField] private ParticleSystem _dashCamera;
    [SerializeField] private ParticleSystem _dashAir;
    [SerializeField] private ParticleSystem _groundParticles;
    [SerializeField] private ParticleSystem _DownParticles;

    [Header("CAMERA")]
    [SerializeField] private CameraFollow _shake;

    public void Dash()
    {
        _dashParticles.Play();
        _dashCamera.Play();
        _dashAir.Play();
    }

    public void Blood()
    {
        _bloodParticles.Play();
    }

    public void Ground()
    {
        _groundParticles.Play();
    }
    public void Downshot()
    {
        _DownParticles.Play();
    }
    
    //public void CutHit(Quaternion direction)
    //{
    //    _hitParticles.transform.localRotation = direction;
    //    _hitParticles.Play();
    //}
}
