using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;

    }

    public int obstacleCount = 20;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public static ObjectPooler instance;



    private void Awake()
    {
        instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);

                //if(obj.GetComponent<PatternPrefab>()!=null)
                // obj.GetComponent<PatternPrefab>().enabled = false;

                obj.SetActive(false);

                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }

    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " does not exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
       

        //if (objectToSpawn.GetComponent<PatternPrefab>() != null)
        //    objectToSpawn.GetComponent<PatternPrefab>().ChangeColor();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        if (objectToSpawn.transform.childCount > 0)
        {
            // Transform[] parent = new Transform[objectToSpawn.transform.childCount];

            for (int i = 0; i < objectToSpawn.transform.childCount; i++)
            {

                objectToSpawn.transform.GetChild(i).gameObject.SetActive(true);
            }

        }
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    public GameObject CSpawnPatternFromPool(string tag, Vector3 position, Quaternion rotation)
    {

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " does not exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);

        if (objectToSpawn.GetComponent<PatternPrefab>() != null)
            objectToSpawn.GetComponent<PatternPrefab>().ChangeColor();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        if (objectToSpawn.transform.childCount > 2)
        {
            // Transform[] parent = new Transform[objectToSpawn.transform.childCount];

            for (int i = 0; i < objectToSpawn.transform.childCount; i++)
            {

                objectToSpawn.transform.GetChild(i).gameObject.SetActive(true);
            }

        }


        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}

   

