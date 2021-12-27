using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shimmering
{
    public class Sequence : Node
    {
        protected List<Node> children = new List<Node>();
        public Sequence(List<Node> children)
        {
            this.children = children;
        }

        public override NodeState Evaluate()
        {
            bool childrenRunning = false;

            foreach (var child in children)
            {
                switch (child.Evaluate())
                {
                    // if one child fail mean whole sequence is fail, so return nodestate.fail
                    case NodeState.FAILURE:
                        nodeState = NodeState.FAILURE;
                        return nodeState;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        childrenRunning = true;
                        continue;
                    default:
                        nodeState = NodeState.SUCCESS;
                        return nodeState;
                }
            }
            // if any child running whole sequence running, otherwise success;
            nodeState = childrenRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return nodeState;
        }
    }
}