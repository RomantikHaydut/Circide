using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int totalScore;
    public TextMeshProUGUI scoreText;

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
        scoreText.text = totalScore.ToString();
        Debug.Log(totalScore);
    }

    public void IncreaseScore(int amount)
    {
        totalScore += amount;
    }
}
