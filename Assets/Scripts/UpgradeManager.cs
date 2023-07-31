using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    public float boardCost;
    public float ballSpawnSpeed;
    public float boardLimit;
    public float ballDoubleChance;
    public float ballAirFriction;
    Thrower thrower;
    BallMovement ballMovement;
    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
        //Script Atamalari
        thrower = FindObjectOfType<Thrower>();
        ballMovement = FindObjectOfType<BallMovement>();
    }
    void Start()
    {

    }


    void Update()
    {

    }
    public void BoardCostInc()
    {
        thrower.spawnDelay -= 0.5f;
    }
    public void BoardLimitInc()
    {

    }
    public void BallFrictionDec()
    {

    }
    public void BallDoubleChanceInc()
    {

    }

}
