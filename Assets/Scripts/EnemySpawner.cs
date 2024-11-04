using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> obstacles;
    public List<GameObject> spawnpoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstacles.Count);
        int spawnpointIndex = Random.Range(0, spawnpoints.Count);
        //Get an Obstacle from the pool
        GameObject obstacle = ObjectPool.Instance.GetObjectFromPool(spawnpoints[spawnpointIndex].transform.position, Quaternion.identity);
    }
}
