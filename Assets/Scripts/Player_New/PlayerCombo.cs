using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCombo
{
    [SerializeField]private Animator _animator;
    private int clickCount = 0;
    private bool canClick = true;


    private Player _player;

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void ManualUpdate()
    {
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            clickCount++;
            _animator.SetInteger("Attack", 1);
        }
    }

    public void OnComboEnd()
    {
        clickCount = 0;
        canClick = true;
    }

    public void OnComboMiddle()
    {
        _animator.SetInteger("Attack", 0);
    }

    public void OnAttack()
    {
        canClick = false;
    }

}
