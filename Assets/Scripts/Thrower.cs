using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Thrower : MonoBehaviour
{
    public float spawnRange = 1.7f;
    public float spawnHeight = 8f;
    public float spawnDelay;
    public float spawnDelayMin;
    public float spawnDelayMax;

    
    
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
    private void OnEnable()
    {
        UpgradeManager.Instance.onThrowerSpeedIncrease.AddListener(DecDelay);
    }
    public void DecDelay(float decrementAmount)
    {
        spawnDelayMin -= 1;
        spawnDelayMax -= 1;
    }
}
