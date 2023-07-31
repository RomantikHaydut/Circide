using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int totalScore;

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
        totalScore = 0;
    }
    private void Update()
    {
        Debug.Log(totalScore);
    }

    public void IncreaseScore(int amount)
    {
        totalScore += amount;
    }
}
