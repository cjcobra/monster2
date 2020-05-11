using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FingerScanButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField]
    private float requiredHoldTime;

    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;

    private float openDoorTrigger;

    public void Start()
    {
        openDoorTrigger = 1;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("OnPointerDown");
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        Reset();
        Debug.Log("OnPointerUp");
    }

    private void Update()
    {
        if (pointerDown)
        {
            //Debug.Log("pointer is down");

            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                Debug.Log("over requuiredTime");

                if (onLongClick != null)
                    onLongClick.Invoke();

                if (openDoorTrigger == 1)
                {
                    OpenDoors();

                }
                //Reset();
            }
            fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
        }
    }

    private void Reset()
    {
        Debug.Log("Reset");

        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }

private void OpenDoors()
    {
        Debug.Log("OpenDoors");


        openDoorTrigger = 2;
    }

}
