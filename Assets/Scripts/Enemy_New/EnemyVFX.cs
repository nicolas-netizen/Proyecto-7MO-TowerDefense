using UnityEngine;

[System.Serializable]
public class EnemyVFX
{
    [Header("PARTICLES")]
    [SerializeField] private ParticleSystem _bloodParticles;

    public void Blood()
    {
        _bloodParticles.Play();
    }
}
