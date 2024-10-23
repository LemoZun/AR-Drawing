using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ARDrawLine drawLine;
    bool pressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        drawLine.StopDrawLine();

    }

    private void Update()
    {
        if(pressed)
        {
            drawLine.StartDrawLine();
        }
    }
}
