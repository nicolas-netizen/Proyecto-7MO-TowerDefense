using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerRotation
{
    private Player _player;
    [SerializeField] private Vector2 _mouseSpeed;
    [SerializeField] private GameObject _camera;

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void ManualUpdate()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if(hor != 0)
        {
            _player.transform.Rotate(Vector3.up * hor * _mouseSpeed.x);
        }

        if (ver != 0)
        {
            float angle = (_camera.transform.localEulerAngles.x - ver * _mouseSpeed.y + 360) % 360;
            if(angle > 180)
            {
                angle -= 360;
            }
            angle = Mathf.Clamp(angle,-5, 5);
            _camera.transform.localEulerAngles = Vector3.right * angle;
        }
    }
}
