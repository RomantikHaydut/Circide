using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class BallMovement : MonoBehaviour
{
    public float speedY = 5.0f;
    public float maxXSpeed = 3.0f;
    private Rigidbody2D ballRb;
    public int score = 1;
    private TMP_Text scoreText;
    private RectTransform scoreRect;
    Vector3 rectScale;
    ScoreManager scoreManager; //Scoremanager
    public static List<BallMovement> Balls = new List<BallMovement>();


    private void Awake()
    {
        ballRb = GetComponent<Rigidbody2D>();
        scoreText = GetComponentInChildren<TMP_Text>();
        scoreRect = GetComponentInChildren<RectTransform>();
        rectScale = scoreRect.transform.localScale;
        scoreText.gameObject.SetActive(false);
        scoreManager = FindObjectOfType<ScoreManager>(); //Score manager initialize 
    }


    private void Start()
    {

        ballRb.velocity = new Vector2(ballRb.velocity.x, speedY);
        


    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //Xteki hýzýný sabitlemek adýna yazýldý
        float speedX = Mathf.Abs(ballRb.velocity.x) > maxXSpeed ? maxXSpeed * Mathf.Sign(ballRb.velocity.x) : ballRb.velocity.x;
        ballRb.velocity = Vector2.ClampMagnitude(ballRb.velocity, maxXSpeed);

    }
    void PopUpText()
    {
        DOTween.Complete(scoreRect);
        scoreRect.transform.localScale = rectScale;
        float duration = 1f;
        float distancetween = 3f;
        scoreText.gameObject.SetActive(true);
        scoreRect.DOAnchorPosY(scoreRect.anchoredPosition.y + distancetween, duration).OnComplete(() =>
        {
            scoreRect.anchoredPosition = new Vector2(scoreRect.anchoredPosition.x, scoreRect.anchoredPosition.y - distancetween);
            scoreText.gameObject.SetActive(false);
        });
        scoreRect.transform.DOScale(scoreRect.transform.localScale * 2, duration / 2).OnComplete(() =>
        {
            scoreRect.transform.DOScale(Vector3.zero, duration / 2);
        });
    }
    //Upgrade Fonksiyonlarý
    
    public void IncreaseSpeed(float incrementAmount)
    {
         speedY += incrementAmount;
    }
    private void OnEnable()
    {
        Balls.Add(this);
    }

    private void OnDisable()
    {
        Balls.Add(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreBoard"))
        {
            scoreManager?.IncreaseScore(score);  //Scoremanagere ulasip total scoreu arttýrmak icin kullandigim fonksiyona yolluyorum
            score = 1; //Topun tekrar spawnlanýrken scorunun 1den baslamasi icin yaptim
            gameObject.SetActive(false);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Board")
        {
            score++;
            PopUpText();
            UpdateScoreText();
            
        }
        void UpdateScoreText()
        {
            scoreText.text = score.ToString();
        }
    }

}