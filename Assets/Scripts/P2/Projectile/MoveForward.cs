using UnityEngine;

namespace bhudev.p2
{
    public class MoveForward : MonoBehaviour
    {
        [SerializeField] private float Speed = 10f;

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
    }
}
