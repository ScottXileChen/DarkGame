using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shimmering
{
    public class PlayerLocomotion : MonoBehaviour
    {
        private PlayerController playerController = null;
        private Transform cameraObject = null;
        private Vector3 moveDirection = Vector3.zero;
        private Vector3 normalVector = Vector3.zero;
        private Vector3 targetPosition = Vector3.zero;
        private Vector2 movementInput = Vector2.zero;
        private Vector2 cameraInput = Vector2.zero;
        private float moveAmount = 0f;

        public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

        private void Start()
        {
            playerController = GetComponent<PlayerController>();
            cameraObject = Camera.main.transform;
            playerController.InputActions.PlayerMovement.Movement.performed += inputActions => MovementInput = inputActions.ReadValue<Vector2>();
            playerController.InputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        private void Update()
        {
            moveDirection = cameraObject.forward * MovementInput.y;
            moveDirection += cameraObject.right * MovementInput.x;
            moveDirection.Normalize();

            float speed = playerController.MovementSpeed;
            moveDirection *= speed;

            Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
            playerController.Rigidbody.velocity = projectedVelocity;

            moveAmount = Mathf.Clamp01(Mathf.Abs(MovementInput.x) + Mathf.Abs(MovementInput.y));
            playerController.PlayerAnimator.UpdateAnimatorValues(moveAmount, 0f);
            HandleRotation(Time.deltaTime);
        }

        private void HandleRotation(float deltaTime)
        {
            Vector3 targetDir = Vector3.zero;

            targetDir = cameraObject.forward * MovementInput.y;
            targetDir += cameraObject.right * MovementInput.x;

            targetDir.Normalize();
            targetDir.y = 0;

            if (targetDir == Vector3.zero)
                targetDir = transform.forward;

            float rs = playerController.RotationSpeed;

            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, rs * deltaTime);

            transform.rotation = targetRotation;
        }
    }
}
