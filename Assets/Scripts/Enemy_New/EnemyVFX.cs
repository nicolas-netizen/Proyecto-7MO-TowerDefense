using UnityEngine;

[System.Serializable]
public class EnemyVFX
{
    [Header("PARTICLES")]
    [SerializeField] private ParticleSystem _bloodParticles;
    [SerializeField] private ParticleSystem _MoneyParticles;

    public void Blood()
    {
        _bloodParticles.Play();
    }
    public void Money()
    {
        _MoneyParticles.Play();
    }
}
