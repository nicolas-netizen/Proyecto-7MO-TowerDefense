using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInput
{
    [SerializeField] private KeyCode _run;

    private Player _player;
    private bool _blockInputs;
    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void ManualUpdate()
    {
        if (!_blockInputs)
        {


            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            Vector3 rawAxis = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            if (rawAxis == Vector3.zero)
            {
                _player.StateController.Idle();
            }
            else
            {
                //if(Input.GetKey(_run))
                //    _player.StateController.Run();
                //else
                _player.StateController.Run();

                _player.MovementController.Move(move.normalized);
            }
        }
    }

    public void BlockInputs()
    {
        _blockInputs = true;
    }

    public void UnlockInputs()
    {
        _blockInputs = false;
    }
}
