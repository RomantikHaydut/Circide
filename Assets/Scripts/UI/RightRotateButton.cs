using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightRotateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float rotateAmount = -1;

    public void OnPointerDown(PointerEventData eventData)
    {
        JumperImage.instance.StartTurn(rotateAmount);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        JumperImage.instance.StopTurn();
    }
}
