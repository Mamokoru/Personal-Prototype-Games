using UnityEngine;
using UnityEngine.InputSystem;

namespace bhudev.Challange1
{
    public class PlayerControllerX : MonoBehaviour
    {
        public float speed;
        public float rotationSpeed;
        public float verticalInput;

        [SerializeField] private InputActionReference moveAction;

        private void OnEnable()
        {
            moveAction.action.Enable();
        }

        private void OnDisable()
        {
            moveAction.action.Disable();
        }

        void FixedUpdate()
        {
            // get the user's vertical input
            verticalInput = moveAction.action.ReadValue<Vector2>().y;

            // move the plane forward at a constant rate
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // tilt the plane up/down based on up/down arrow keys
            transform.Rotate(Vector3.right * verticalInput * rotationSpeed * Time.deltaTime);
        }
    }
}