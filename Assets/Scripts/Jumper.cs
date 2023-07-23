using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    private Vector2 initialPosition;
    private float deltaX, deltaY;

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
                    transform.position = new Vector2(touchPosition.x - deltaX, touchPosition.y - deltaY);
                    this.enabled = false;
                    break;
            }
        }
    }
}
