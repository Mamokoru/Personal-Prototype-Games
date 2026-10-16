using UnityEngine;

public class RandomizeProjectile : MonoBehaviour
{
    [SerializeField] private GameObject[] projectilePrefabs;

    private void Start()
    {
        int animalIndex = Random.Range(0, projectilePrefabs.Length);

        Instantiate(projectilePrefabs[animalIndex], transform.position, transform.rotation, transform);
    }
}
