using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shimmering;
public class CreateTree : MonoBehaviour
{
    private Material material;
    private Node rootNode;
    void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().material;

        Move move = new Move(this.gameObject, 1);

        Sequence testSequence = new Sequence(new List<Node> { move });

        rootNode = new Selector(new List<Node>{ testSequence });
    }

    // Update is called once per frame
    void Update()
    {
        rootNode.Evaluate();
        if(rootNode.mNodeState ==NodeState.FAILURE)
        {
            material.color = Color.red;
        }
        if (rootNode.mNodeState == NodeState.SUCCESS)
        {
            material.color = Color.green;
        }
        if (rootNode.mNodeState == NodeState.RUNNING)
        {
            material.color = Color.yellow;
        }
    }
}
