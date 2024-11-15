using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanlderAnimationUpBot : MonoBehaviour
{
    [SerializeField] private Trap _trap;

    public void CooldownStop()
    {
        _trap.StateSwitch(false);
    }

    public void StartDamage()
    {
        _trap.StateDamage(true);
    }

    public void StopDamage()
    {
        _trap.StateDamage(false);
    }
}
