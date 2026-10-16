using UnityEngine;
using UnityEngine.InputSystem;

namespace bhudev.P1
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] InputActionReference MoveAction;
        [SerializeField] float runSpeed = 5f, turnSpeed = 10f;
        Vector2 moveInput;

        private void OnEnable()
        {
            MoveAction.action.Enable();
        }
        private void OnDisable()
        {
            MoveAction.action.Disable();
        }

        void Update()
        {
            moveInput = MoveAction.action.ReadValue<Vector2>();

            transform.Translate(Vector3.forward * moveInput.y * runSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
        }
    }
}
