using UnityEngine;

[System.Serializable]
public class EnemyVFX
{
    [Header("PARTICLES")]
    [SerializeField] private ParticleSystem _bloodParticles;
    [SerializeField] private ParticleSystem _MoneyParticles;
    [SerializeField] private ParticleSystem _MoneyDie;
    [SerializeField] private ParticleSystem _DieBoss;
    [SerializeField] private ParticleSystem _AbailityBoss;

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
    public void AbilityBoss()
    {
        _AbailityBoss.Play();
    }

}
