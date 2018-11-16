using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public GameObject Panel;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        AudioManager.audioManager.ButtonHover();
        if(Panel != null)
        {
            Panel.SetActive(true);

        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        AudioManager.audioManager.ButtonClick();
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (Panel != null)
        {
            Panel.SetActive(false);

        }
    }

	
}
