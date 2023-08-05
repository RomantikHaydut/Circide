using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }
    public FloatEvent onSpeedUpgraded;
    public FloatEvent onDecSpawnDelay;
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
        
    }
    public void IncSpeed(float incrementAmount)
    {
        onSpeedUpgraded?.Invoke(incrementAmount);
    }
    public void DecSpawnDelay(float decreamentAmount)
    {

    }

}
