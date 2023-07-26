using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BallMovement : MonoBehaviour
{
    public float speedY = 5.0f;
    public float maxXSpeed = 3.0f;
    private Rigidbody2D ballRb;
    private int score = 1; 
    private TMP_Text scoreText;
    private void Awake()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
        ballRb.velocity = new Vector2(ballRb.velocity.x, speedY);
        scoreText = GetComponentInChildren<TMP_Text>();
        
    }
    private void FixedUpdate()
    {
        //Xteki hýzýný sabitlemek adýna yazýldý
        float speedX = Mathf.Abs(ballRb.velocity.x) > maxXSpeed ? maxXSpeed * Mathf.Sign(ballRb.velocity.x) : ballRb.velocity.x;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ScoreBoard"))
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Board") 
        {
            score++; 
            UpdateScoreText(); 
        }
        void UpdateScoreText()
        {
            scoreText.text = score.ToString(); 
        }
    }
}