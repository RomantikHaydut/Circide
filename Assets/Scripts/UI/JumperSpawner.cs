using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class JumperSpawner : MonoBehaviour, IPointerDownHandler
{
    public static JumperSpawner instance;
    [SerializeField] private Transform spawnPosTransform;
    [SerializeField] private GameObject jumperPrefab;
    [SerializeField] private float spawnRotationZ;

    private void Awake()
    {
        instance = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SpawnJumper();
        JumperImage.instance.ResetRotation();
    }

    public void SetSpawnRotationZ(float newRotation)
    {
        spawnRotationZ = newRotation;
    }

    private void SpawnJumper()
    {
        if (Mathf.Abs(spawnRotationZ) <= 0.5f)
        {
            spawnRotationZ = 1;
        }
        GameObject jumperClone = Instantiate(jumperPrefab, spawnPosTransform.position, Quaternion.identity);
        jumperClone.transform.eulerAngles = new Vector3(jumperClone.transform.eulerAngles.x, jumperClone.transform.eulerAngles.y, spawnRotationZ);
    }
}

