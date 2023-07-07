using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWaveable
{
    void NextNode(Node nextNode, Node thisNode, List<Node> ignoreNodes);
}

