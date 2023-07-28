using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    private Vector2 initialPosition;
    private float deltaX, deltaY;
    private BoxCollider2D ballCollider;
    bool isColliding;
    private void Awake()
    {
        ballCollider = GetComponent<BoxCollider2D>();
        ballCollider.isTrigger = true;
    }
    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPosition.x - transform.position.x;
                    deltaY = touchPosition.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    transform.position = new Vector2(touchPosition.x - deltaX, touchPosition.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    if (!isColliding)
                    {
                        transform.position = new Vector2(touchPosition.x - deltaX, touchPosition.y - deltaY);
                        ballCollider.enabled = true;
                        ballCollider.isTrigger = false;
                        this.enabled = false;

                    }
                    else
                    {
                        YouDidItWrong();
                    }
                    break;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Jumper xx))
        {
            isColliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Jumper xx))
        {
            isColliding = false;
        }
    }
    void YouDidItWrong()
    {
        Destroy(gameObject);
    }
}


