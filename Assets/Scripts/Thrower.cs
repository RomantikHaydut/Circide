using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public float spawnRange = 1.7f;
    public float spawnHeight = 20.0f;
    public float spawnDelay = 0.5f;
    public float spawnDelayMin = 0.5f;
    public float spawnDelayMax = 2.5f;
    
    #region Pool
    public List<GameObject> poolList;
    public GameObject objectToPool;
    public int amountToPool;
    #endregion

    private void Awake()
    {
        
    }
    void Start()
    {
        poolList = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            poolList.Add(obj);
        }

        InvokeRepeating("SpawnObject", spawnDelayMin, spawnDelay);
    }

    void SpawnObject()
    {
        GameObject pooledObject = GetPooledObject();
        if (pooledObject == null)
        {
            return;
        }
        float spawnX = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(spawnX, spawnHeight, 0);
        pooledObject.transform.position = spawnPosition;
        pooledObject.SetActive(true);
        spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolList.Count; i++)
        {
            if (!poolList[i].activeInHierarchy)
            {
               
                return poolList[i];

            }
        }
        return null;
    }
}
