using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [Header("Zombie Settings")]
    public GameObject zombiePrefab;
    public Transform spawnPoint;
    public float spawnRate = 2f; 

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnZombie();
            timer = 0f;
        }
    }

    void SpawnZombie()
    {
        Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
    }
}

