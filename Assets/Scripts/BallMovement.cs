using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speedY = 5.0f;
    public float maxXSpeed = 3.0f;
    private Rigidbody2D ballRb;

    private void Awake()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
        ballRb.velocity = new Vector2(ballRb.velocity.x, speedY);
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
}