using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shimmering
{
    public class Selector : Node
    {
        protected List<Node> children = new List<Node>();
        public Selector(List<Node> children)
        {
            this.children = children;
        }

        public override NodeState Evaluate()
        {
            foreach (var child in children)
            {
                switch (child.Evaluate())
                {
                    // if child fail, will just go to next child
                    case NodeState.FAILURE:
                        break;
                    // if child success whole the selector is success
                    case NodeState.SUCCESS:
                        nodeState = NodeState.SUCCESS;
                        return nodeState;
                    // if child running whole the selector running
                    case NodeState.RUNNING:
                        nodeState = NodeState.RUNNING;
                        return nodeState;
                    default:
                        break;
                }
            }
            nodeState = NodeState.FAILURE;
            return nodeState;
        }
    }
}
