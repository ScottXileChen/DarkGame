using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shimmering
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private PlayerController playerController;
        public Animator Animator { get => GetComponent<Animator>(); }

        private int vertical = 0;
        private int horizontal = 0;

        private void Start()
        {
            playerController = GetComponentInParent<PlayerController>();
            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizontal");
        }

        public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement)
        {
            float v = 0f;
            if (verticalMovement > 0f && verticalMovement < 0.55f)
                v = 0.5f;
            else if (verticalMovement > 0.55f)
                v = 1f;
            else if (verticalMovement < 0f && verticalMovement > -0.55f)
                v = -0.5f;
            else if (verticalMovement < -0.55f)
                v = -1f;
            else
                v = 0f;

            float h = 0f;
            if (horizontalMovement > 0f && horizontalMovement < 0.55f)
                h = 0.5f;
            else if (horizontalMovement > 0.55f)
                h = 1f;
            else if (horizontalMovement < 0f && horizontalMovement > -0.55f)
                h = -0.5f;
            else if (horizontalMovement < -0.55f)
                h = -1f;
            else
                h = 0f;

            Animator.SetFloat(vertical, v, 0.1f, Time.deltaTime);
            Animator.SetFloat(horizontal, h, 0.1f, Time.deltaTime);
        }
    }
}

