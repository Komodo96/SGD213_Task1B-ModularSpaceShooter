using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    // Object to spawn
    [SerializeField]
    private GameObject spawnObject;

    // Delay between spawns
    [SerializeField]
    private float spawnDelay = 2f;

    //The enemy spawn area
    private Renderer enemySpawnArea;

    // Use this for initialization
    void Start()
    {
        //Get the enemy spawn area and set it asa variable
        enemySpawnArea = GetComponent<Renderer>();

        // Stop our Spawner from being visible!
        enemySpawnArea.enabled = false;

        // Call the Spawn function and then repeatedly call it after a delay. The delay time is defined by the spawn delay variable
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    //Function used to spawn enemies
    void Spawn()
    {
        //Sets the bounds for the enemy spawn area
        float x1 = transform.position.x - enemySpawnArea.bounds.size.x / 2;
        float x2 = transform.position.x + enemySpawnArea.bounds.size.x / 2;

        // Randomly pick a point within the enemy spawn area
        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        // Spawn the object at the 'spawnPoint' position
        Instantiate(spawnObject, spawnPoint, Quaternion.identity);
    }
}
