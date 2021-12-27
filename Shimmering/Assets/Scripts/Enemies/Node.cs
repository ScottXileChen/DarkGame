using System.Collections.Generic;

namespace Shimmering
{
    public enum NodeState
    {
        SUCCESS,
        FAILURE,
        RUNNING
    }

    public abstract class Node
    {
        protected NodeState nodeState;

        List<Node> Nodes = new List<Node>();

        //property to get node state
        public NodeState mNodeState { get { return nodeState; } }

        public abstract NodeState Evaluate();
    }

}
