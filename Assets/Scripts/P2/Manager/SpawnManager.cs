using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public RandomizeProjectile animalPrefabs;
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float randomInterval = 20;
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;

    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, randomInterval);
    }
    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),
                  0, spawnPosZ);
        Instantiate(animalPrefabs, spawnPos,
        animalPrefabs.transform.rotation);
    }
}
