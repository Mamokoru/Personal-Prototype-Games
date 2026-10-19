using UnityEngine;

namespace bhudev.p3
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] obstaclePrefab;
        private Vector3 spawnPos = new Vector3(25, 0, 0);
        private float startDelay = 2;
        private float repeatRate = 2;
        [SerializeField] private PlayerController playerControllerScript;
        void Start()
        {
            InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        }

        void Update()
        {

        }

        void SpawnObstacle()
        {
            if (playerControllerScript.gameOver == false)
            {
                int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
                Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation).AddComponent<MoveLeft>();
            }

        }
    }
}