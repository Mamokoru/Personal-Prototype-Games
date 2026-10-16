using UnityEngine;

namespace bhudev.Challange1
{
    public class RotateInAxis : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 20f;
        private void Update()
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}
