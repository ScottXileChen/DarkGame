using UnityEngine;

namespace Shimmering
{
    public class Move : Node
    {
        GameObject ai;
        float moveSpeed = 0;
        int i = 0;
        public Move(GameObject gameObject, float movespeed)
        {
            ai = gameObject;
            moveSpeed = movespeed * Time.deltaTime;
        }

        public override NodeState Evaluate()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                return nodeState = NodeState.FAILURE;
            }

            if (i == 0)
            {
                ai.transform.position = Vector3.MoveTowards(ai.transform.position, new Vector3(0.0f, 1.0f, 0.0f), moveSpeed);
                nodeState = NodeState.RUNNING;
            }
            if (ai.transform.position == new Vector3(0, 1, 0))
            {
                i++;
            }
            if (i > 0)
            {
                ai.transform.position = Vector3.MoveTowards(ai.transform.position, new Vector3(5.0f, 1.0f, 0.0f), moveSpeed);
                if (ai.transform.position == new Vector3(5, 1, 0))
                {
                    nodeState = NodeState.SUCCESS;
                    i = 0;
                }
            }
            return nodeState;
        }
    }
}