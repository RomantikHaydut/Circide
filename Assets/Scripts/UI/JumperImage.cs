using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperImage : MonoBehaviour
{
    public static JumperImage instance;
    private bool canTurn = false;
    [SerializeField] private float turnSpeed = 2f;
    private float turnDirection = 0;
    private float rotationZ;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Turn();
    }

    private void Turn()
    {
        if (canTurn)
        {
            transform.eulerAngles += new Vector3(0, 0, turnDirection * turnSpeed * Time.deltaTime);
            rotationZ = transform.eulerAngles.z;
        }
    }

    public void StartTurn(float direction)
    {
        turnDirection = direction;
        canTurn = true;
    }

    public void StopTurn()
    {
        canTurn = false;
        JumperSpawner.instance.SetSpawnRotationZ(rotationZ);
    }

    public void ResetRotation()
    {
        transform.eulerAngles = Vector3.zero;
        JumperSpawner.instance.SetSpawnRotationZ(0);
    }
}
