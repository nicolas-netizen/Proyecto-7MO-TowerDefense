using UnityEngine;

[System.Serializable]
public class EnemyVFX
{
    [Header("PARTICLES")]
    [SerializeField] private ParticleSystem _bloodParticles;
    [SerializeField] private ParticleSystem _MoneyParticles;
    [SerializeField] private ParticleSystem _MoneyDie;
    [SerializeField] private ParticleSystem _DieBoss;

    public void Blood()
    {
        _bloodParticles.Play();
    }
    public void Money()
    {
        _MoneyParticles.Play();
    }
    public void MoneyDie()
    {
        _MoneyDie.Play();
    }
    public void DieBoss()
    {
        _DieBoss.Play();
    }

}
