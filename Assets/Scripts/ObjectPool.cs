using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [SerializeField] private List<GameObject> obstaclePrefab;

    public int poolSize = 10;

    private List<GameObject> pooledObstacles;
    private Queue<GameObject> pool = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < obstaclePrefab.Count; i++)
        {
            GameObject obj = Instantiate(obstaclePrefab[i]);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }
    public GameObject GetObjectFromPool(Vector3 position, Quaternion rotation)
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            return obj;
        }
        else
        {
            Debug.LogWarning("La piscina esta vacia!");
            return null;
        }
    }
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
