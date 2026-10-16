using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace bhudev.p2
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionReference moveAction;
        [SerializeField] private InputActionReference firingAction;
        [SerializeField] private GameObject ProjectileFood;
        [SerializeField] private float Speed = 10f;
        [SerializeField] private float xRange = 10f;

        private Vector2 moveInput;

        private void OnEnable()
        {
            moveAction.action.Enable();
            firingAction.action.Enable();
        }
        private void OnDisable()
        {
            moveAction.action.Disable();
            firingAction.action.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < -xRange || transform.position.x > xRange)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xRange, xRange), transform.position.y, transform.position.z);
            }

            moveInput = moveAction.action.ReadValue<Vector2>();

            transform.Translate(Vector3.right * moveInput.x * Speed * Time.deltaTime);

            if (firingAction.action.triggered)
            {
                Instantiate(ProjectileFood, transform.position, transform.rotation);
            }
        }
    }
}
