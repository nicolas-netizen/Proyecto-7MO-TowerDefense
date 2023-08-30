using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEscape : MonoBehaviour, ISerializationCallbackReceiver
{
    private bool _playerInside;
    [SerializeField] private NodeManager _nodeManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerInside = false;
        }
    }

    public bool CheckPlayerPosition()
    {
        return _playerInside;
    }

    public void OnBeforeSerialize()
    {
        if (!_nodeManager.Nodes.Contains(this))
        {
            _nodeManager.Nodes.Add(this);
        }
    }

    public void OnAfterDeserialize()
    {

    }
}
