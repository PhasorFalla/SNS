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
        Fabric.EventManager.Instance.PostEvent("UI/UIHover", Camera.main.gameObject);
        if (Panel != null)
        {
            Panel.SetActive(true);

        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Fabric.EventManager.Instance.PostEvent("UI/UISelect", Camera.main.gameObject);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (Panel != null)
        {
            Panel.SetActive(false);

        }
    }

	
}
