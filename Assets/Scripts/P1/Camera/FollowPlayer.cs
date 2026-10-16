using UnityEngine;

namespace bhudev.P1
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Vector3 offset = new Vector3(0, 5, -7);
        void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }
    }
}
