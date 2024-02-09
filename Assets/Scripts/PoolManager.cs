using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public static PoolManager Instance;

    [System.Serializable]
    public class Pool
    {
        [SerializeField] string parentName;
        [SerializeField] GameObject prefab;
        [SerializeField] int poolSize;
        [SerializeField] List<GameObject> pooledObjects;
    }

    [SerializeField] List<Pool> pools;
    
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        

        GameObject obj;

        foreach (Pool pool in pools)
        {
            GameObject parent = new GameObject(parentName);

            for (int i = 0; i < poolSize; i++)
            {
                obj = Instantiate(prefab);
                obj.transform.SetParent(parent.transform);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        
    }

    public GameObject GetPooledObjects(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < poolSize; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                GameObject objectToSpawn;
                objectToSpawn = pooledObjects[i];
                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;
                return objectToSpawn;
            }
        }

        return null;
    }
}
