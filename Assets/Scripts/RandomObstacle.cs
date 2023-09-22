using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{
    // List of obstacle prefabs
    [SerializeField] private GameObject[] obstaclePrefabs;

    // Number of obstacles to instantiate
    private int numberOfObstacles = 10;

    // Minimum and maximum spawn position along the track
    private float minSpawnZ = -16f;
    private float maxSpawnZ = 383f;
    private float minSpawnX = -8f;
    private float maxSpawnX = 8f;

    // Start is called before the first frame update
    private void Start()
    {
        InstantiateObstacles();
    }

    // This method instantiates obstacles into the game
    private void InstantiateObstacles()
    {
        // Make sure there are obstacle prefabs to instantiate
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
        {
            Debug.LogError("No obstacle prefabs assigned to the RandomObstacle script.");
            return;
        }

        // Instantiate random obstacles
        for (int i = 0; i < numberOfObstacles; i++)
        {
            // Randomly select an obstacle prefab from the list
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            // Randomly generate a spawn position along the track
            float spawnZ = Random.Range(minSpawnZ, maxSpawnZ);
            float spawnX = Random.Range(minSpawnX, maxSpawnX);
            Vector3 spawnPosition = new Vector3(spawnX, 2.5f, spawnZ);

            // Instantiate the selected obstacle at the spawn position
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // Attach the obstacle to the RandomObstacle GameObject as a child
            obstacle.transform.parent = transform;
        }
    }
}