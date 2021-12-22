using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shimmering
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerLocomotion))]
    public class PlayerController : MonoBehaviour
    {
        // Requires:
        public GameObject normalCamera = null;

        // Stats:
        [Header("Locomotion Stats")]
        [SerializeField]
        private float movementSpeed = 5f;
        [SerializeField]
        private float rotationSpeed = 10f;

        // Settings:
        private DefaultPlayerControls inputActions = null;

        // Properties:
        public Rigidbody Rigidbody { get => GetComponent<Rigidbody>(); }
        public PlayerLocomotion PlayerLocomotion { get => GetComponent<PlayerLocomotion>(); }
        public PlayerAnimator PlayerAnimator { get => GetComponentInChildren<PlayerAnimator>(); }
        public DefaultPlayerControls InputActions { get => inputActions; set => inputActions = value; }
        public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }

        private void Awake()
        {
            InputActions = new DefaultPlayerControls();
            InputActions.Enable();
        }
    }
}
