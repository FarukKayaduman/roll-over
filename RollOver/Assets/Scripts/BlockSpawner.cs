using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject blockPrefab;

    public GameObject player;

    public Vector3 spawnerOffset;

    public float timeBetweenWaves = 1f;

    private float timeToSpawn = 2f;

    void Update()
    {
        if(Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
        }

        transform.position = new Vector3 (transform.position.x, 
                                          transform.position.y, 
                                          player.transform.position.z + spawnerOffset.z);
    }

    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(blockPrefab, new Vector3(spawnPoints[i].position.x,
                                        1, spawnPoints[i].position.z), 
                                        Quaternion.identity);
            }
        }
    }

}
