using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }
    public FloatEvent onThrowerSpeedDecrease;
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
    public void DecDelayTime(float decrementAmount)
    {
        onThrowerSpeedDecrease?.Invoke(decrementAmount);
    }
    public void IncSpeed(float incrementAmount)
    {
        foreach (BallMovement ball in BallMovement.Balls)
        {
            ball.IncreaseSpeed(incrementAmount);
        }
    }
    


}
